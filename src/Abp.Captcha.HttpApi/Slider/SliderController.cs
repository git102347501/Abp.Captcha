using Abp.Captcha.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条控制器
    /// </summary>
    public class SliderController : AbpController
    {
        private readonly ISliderAppService _sliderAppService;
        protected SliderController(ISliderAppService sliderAppService)
        {
            LocalizationResource = typeof(CaptchaResource);
            _sliderAppService = sliderAppService;
        }

        /// <summary>
        /// 获取滑条验证令牌
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<string> GetVerificationTokenAsync(string input)
        {
            var actionData = new SliderActionModel(HttpContext.Connection.RemoteIpAddress.ToString());
            return await _sliderAppService.GetVerificationTokenAsync(new ValidationModel<string>(input, actionData));
        }
    }
}
