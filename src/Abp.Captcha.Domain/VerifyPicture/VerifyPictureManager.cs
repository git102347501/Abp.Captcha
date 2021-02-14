using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Services;

namespace Abp.Captcha.VerifyPicture
{
    /// <summary>
    /// 图形验证码领域服务实现
    /// </summary>
    public class VerifyPictureManager: IDomainService, IVerifyPictureManager
    {
        private readonly IVerifyPictureProvider _verifyPictureProvider;
        private readonly IDistributedCache<VerifyPictureData> _cache;

        public VerifyPictureManager(IVerifyPictureProvider verifyPictureProvider, IDistributedCache<VerifyPictureData> distributedCache)
        {
            _verifyPictureProvider = verifyPictureProvider;
            _cache = distributedCache;
        }

        /// <summary>
        /// 创建图形验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public async Task<DownloadModel> CreateAsync(int length)
        {
            var data = new VerifyPictureData(Guid.NewGuid().ToString(), _verifyPictureProvider.CreateCode(length), 3);

            var content = await _verifyPictureProvider.GenerateAsync(data.Code);
            // 写入缓存
            await _cache.SetAsync(data.Index, data, 
                new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes((double)data.TermValidityMinutes) });

            return new DownloadModel(data.Index, content);
        }

        /// <summary>
        /// 验证图形验证码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> Validation(ValidationModel data)
        {
            var result = await _cache.GetAsync(data.Index);
            return result != null ? result.IsValid(data.Code) : false;
        }
    }
}
