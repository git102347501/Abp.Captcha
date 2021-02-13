using Abp.Captcha.VerifyPicture.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Abp.Captcha.VerifyPicture
{
    /// <summary>
    /// 验证图片应用服务接口
    /// </summary>
    public interface IVerifyPictureAppService : IApplicationService
    {
        /// <summary>
        /// 获取验证图片
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<VerifyPictureOutput> GetAsync(VerifyPictureInput input);

        /// <summary>
        /// 验证图片验证码有效性
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> ValidationAsync(ValidationModel input);
    }
}
