using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条领域服务
    /// </summary>
    public interface ISilderManager : IDomainService
    {
        /// <summary>
        /// 获取滑条验证令牌
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> GetVerificationTokenAsync(ValidationModel<string> data);

        /// <summary>
        /// 验证令牌
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> VerificationTokenAsync(ValidationModel<string> data);

        /// <summary>
        /// 验证图形验证码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> VerificationAsync(ValidationModel<int[]> data);
    }
}
