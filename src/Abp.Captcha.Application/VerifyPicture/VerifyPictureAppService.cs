using MaigcalConch.Abp.Captcha.VerifyPicture.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MaigcalConch.Abp.Captcha.VerifyPicture
{
    /// <summary>
    /// 验证图片应用服务实现
    /// </summary>
    public class VerifyPictureAppService : CaptchaAppService, IVerifyPictureAppService
    {
        private readonly IVerifyPictureManager _verifyPictureManager;

        public VerifyPictureAppService(IVerifyPictureManager verifyPictureManager)
        {
            _verifyPictureManager = verifyPictureManager;
        }

        /// <summary>
        /// 获取验证图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<VerifyPictureOutput> GetAsync(VerifyPictureInput input)
        {
            var data = await _verifyPictureManager.CreateAsync(input.Length);
            return ObjectMapper.Map<DownloadModel, VerifyPictureOutput>(data);
        }

        /// <summary>
        /// 获取验证图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<bool> ValidationAsync(ValidationModel input)
        {
            return await _verifyPictureManager.ValidationAsync(input);
        }
    }
}
