using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace Abp.Captcha.VerifyPicture
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CaptchaAttribute : Attribute, IAsyncActionFilter, ITransientDependency
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var data = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "ImgValue");
            var index = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "ImgIndex");
            
            if (index.Key.IsNullOrWhiteSpace() || data.Key.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException("The verification code is not valid!");
            }

            var _verifyPictureAppService = context.HttpContext.RequestServices.GetService(typeof(IVerifyPictureAppService)) as IVerifyPictureAppService;
            if (!await _verifyPictureAppService.ValidationAsync(new ValidationModel(index.Value, data.Value)))
            {
                throw new UserFriendlyException("The verification code is wrong!");
            }
            await next();
        }
    }
}
