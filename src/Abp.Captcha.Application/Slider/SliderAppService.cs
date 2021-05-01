using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条验证应用服务实现
    /// </summary>
    public class SliderAppService : CaptchaAppService, ISliderAppService
    {
        private readonly ISilderManager _silderManager;

        public SliderAppService(ISilderManager verifyPictureManager)
        {
            _silderManager = verifyPictureManager;
        }

        /// <summary>
        /// 获取滑条验证令牌
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [RemoteService(IsMetadataEnabled = false)]
        public async Task<string> GetVerificationTokenAsync(ValidationModel<string> input)
        {
            return await _silderManager.GetVerificationTokenAsync(input);
        }

        /// <summary>
        /// 验证滑条令牌是否有效
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [RemoteService(IsMetadataEnabled = false)]
        public async Task<bool> VerificationTokenAsync(ValidationModel<string> input)
        {
            return await _silderManager.VerificationTokenAsync(input);
        }

        /// <summary>
        /// 验证滑条数据是否有效
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [RemoteService(IsMetadataEnabled = false)]
        public async Task<bool> VerificationAsync(ValidationModel<int[]> input)
        {
            return await _silderManager.VerificationAsync(input);
        }
    }
}
