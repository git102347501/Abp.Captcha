using Abp.Captcha.Slider.Dtos;
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
        /// 验证是否合法
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<bool> ValidationAsync(ValidationModel input);
    }
}
