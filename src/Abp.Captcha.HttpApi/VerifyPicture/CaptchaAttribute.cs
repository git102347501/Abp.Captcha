using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Abp.Captcha.VerifyPicture
{
    public class CaptchaAttribute : Attribute, IAsyncActionFilter
    {
        private readonly IVerifyPictureAppService _verifyPictureAppService;

        public CaptchaAttribute(IVerifyPictureAppService verifyPictureAppService)
        {
            _verifyPictureAppService = verifyPictureAppService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var index = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "ImgIndex");
            var data = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "ImgValue");
            
            if (!index.Key.IsNullOrWhiteSpace() && !data.Key.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException("The verification code is not valid!");
            }

            if (await _verifyPictureAppService.ValidationAsync(new ValidationModel(index.Value, data.Value)))
            {
                throw new UserFriendlyException("The verification code is wrong!");
            }
        }
    }
}
