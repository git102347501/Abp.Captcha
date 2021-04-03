
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Abp.Captcha.Slider
{
    /// <summary>
    /// 滑条验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class SliderAttribute : Attribute, IAsyncActionFilter, ITransientDependency
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var _verifyPictureAppService = context.HttpContext.RequestServices.GetService(typeof(ISliderAppService)) as ISliderAppService;
            var data = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Data");

            var actionData = new SliderActionModel(context.HttpContext.Connection.RemoteIpAddress.ToString());
            if (data.Key.IsNullOrWhiteSpace())
            {
                var token = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Token");
                if (token.Key.IsNullOrWhiteSpace())
                {
                    var valTokendata = new ValidationModel<string>(token.Value, actionData);
                    if (!await _verifyPictureAppService.VerificationTokenAsync(valTokendata))
                    {
                        throw new UserFriendlyException("The verification code is wrong!");
                    }
                }
                throw new UserFriendlyException("The verification code is not valid!");
            }

            var valdata = new ValidationModel<int[]>(Array.ConvertAll(data.Value.ToString().Split(','), int.Parse), actionData);
            if (!await _verifyPictureAppService.VerificationAsync(valdata))
            {
                throw new UserFriendlyException("The verification code is wrong!");
            }
            await next();
        }
    }
}
