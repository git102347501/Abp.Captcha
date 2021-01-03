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
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<DownloadModel> CreateAsync(int data)
        {
            var index = Guid.NewGuid().ToString();
            // 创建验证码
            var code = _verifyPictureProvider.CreateCode(data);
            // 生成验证码图片
            var content = await _verifyPictureProvider.GenerateAsync(code);
            // 写入缓存
            _cache.Set(index, new VerifyPictureData(index, code));
            return new DownloadModel(index, content);
        }

        /// <summary>
        /// 验证图形验证码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> Validation(ValidationModel data)
        {
            var result = await _cache.GetAsync(data.Index);
            return result.IsValid(data.Code);
        }
    }
}
