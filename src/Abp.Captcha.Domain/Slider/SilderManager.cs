using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Services;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条领域服务实现
    /// </summary>
    public class SilderManager : DomainService, ISilderManager
    {
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache<SliderActionCacheModel> _cache;
        private readonly ISliderVerificationProvider _sliderVerificationProvider;
        private readonly IDistributedCache<SliderActionTokenCacheModel> _cacheToken;

        public SilderManager(IConfiguration configuration, IDistributedCache<SliderActionCacheModel> cache, ISliderVerificationProvider sliderVerificationProvider)
        {
            _cache = cache;
            _configuration = configuration;
            _sliderVerificationProvider = sliderVerificationProvider;
        }

        /// <summary>
        /// 获取滑条验证令牌
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<string> GetVerificationTokenAsync(ValidationModel<string> data)
        {
            // 审查会话安全性
            await VerificationActionAsync(data.ActionData);

            // 缓存会话
            var id = GuidGenerator.Create().ToString();
            await _cacheToken.SetAsync(id, new SliderActionTokenCacheModel(data.ActionData.Ip));
            return id;
        }

        /// <summary>
        /// 验证滑条是否有效
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> VerificationTokenAsync(ValidationModel<string> data)
        {
            // 审查会话安全性
            await VerificationActionAsync(data.ActionData);

            var result = await _cacheToken.GetAsync(data.Data);

            if (result != null)
            {
                // 验证IP同源
                return result.Ip == data.ActionData.Ip;
            }
            return false;
        }

        /// <summary>
        /// 验证滑条是否有效
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> VerificationAsync(ValidationModel<int[]> data)
        {
            // 审查会话安全性
            await VerificationActionAsync(data.ActionData);

            return await _sliderVerificationProvider.VerificationAsync(data);
        }

        /// <summary>
        /// 审核滑条会话安全性
        /// </summary>
        /// <param name="sliderAction">会话信息</param>
        /// <returns></returns>
        public virtual async Task VerificationActionAsync(SliderActionModel sliderAction)
        {
            var cacheItem = await _cache.GetAsync(sliderAction.Ip);
            var rquestsCount = int.Parse(_configuration["Verification:Slider:RequestsCount"]);

            if (cacheItem != null && cacheItem.Count > rquestsCount)
            {
                throw new UserFriendlyException("请求频繁,请在60秒后重新尝试");
            }

            if (cacheItem == null)
            {
                await _cache.SetAsync(sliderAction.Ip,
                    new SliderActionCacheModel(sliderAction.Ip),
                    new DistributedCacheEntryOptions { 
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1) 
                    });
            } 
            else
            { 
                cacheItem.AddCount();
                await _cache.SetAsync(sliderAction.Ip, cacheItem);
            }
        }
    }
}
