using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条领域服务实现
    /// </summary>
    public class SilderManager : DomainService, ISilderManager
    {
        private readonly ISliderVerificationProvider _sliderVerificationProvider;
        public SilderManager(ISliderVerificationProvider sliderVerificationProvider)
        {
            _sliderVerificationProvider = sliderVerificationProvider;
        }

        /// <summary>
        /// 验证滑条是否有效
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public Task<bool> VerificationAsync(ValidationModel data)
        {
            _sliderVerificationProvider.VerificationAsync(data);
        }
    }
}
