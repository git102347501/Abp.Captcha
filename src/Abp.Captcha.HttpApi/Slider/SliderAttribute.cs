
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace MaigcalConch.Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SliderAttribute : Attribute, IAsyncActionFilter, ITransientDependency
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var data = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Data");

            var actionData = new SliderActionModel(context.HttpContext.Connection.RemoteIpAddress.ToString(),
                context.HttpContext.Request.Headers["User-Agent"].ToString());
            var _sliderAppService = context.HttpContext.RequestServices.GetService(typeof(ISliderAppService)) as ISliderAppService;
            if (data.Key.IsNullOrWhiteSpace())
            {
                var token = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Token");
                if (token.Key.IsNullOrWhiteSpace())
                {
                    var valTokendata = new ValidationModel<string>(token.Value, actionData);
                    if (!await _sliderAppService.VerificationTokenAsync(valTokendata))
                    {
                        throw new UserFriendlyException("The verification code is wrong!");
                    }
                }
                throw new UserFriendlyException("The verification code is not valid!");
            }

            var valdata = new ValidationModel<int[]>(Array.ConvertAll(data.Value.ToString().Split(','), int.Parse), actionData);
            if (!await _sliderAppService.VerificationAsync(valdata))
            {
                throw new UserFriendlyException("The verification code is wrong!");
            }
            await next();
        }
    }
}
