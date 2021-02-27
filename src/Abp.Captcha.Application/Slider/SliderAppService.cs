using Abp.Captcha.Slider.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条验证应用服务实现
    /// </summary>
    public class SliderAppService : CaptchaAppService, ISliderAppService
    {
        public async Task<bool> ValidationAsync(ValidationModel input)
        {
            return await Task.Run(() => false);
        }
    }
}
