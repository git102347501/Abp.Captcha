using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条验证应用服务接口
    /// </summary>
    public interface ISliderAppService : IApplicationService
    {
        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<string> GetVerificationTokenAsync(ValidationModel<string> input);

        /// <summary>
        /// 验证滑条令牌合法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> VerificationTokenAsync(ValidationModel<string> input);

        /// <summary>
        /// 验证是否合法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> VerificationAsync(ValidationModel<int[]> input);
    }
}
