using MagicalConch.Abp.Captcha.IpAction;
using MaigcalConch.Abp.Captcha.VerifyPicture;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace MagicalConch.Abp.Captcha.UserAction
{
    [AttributeUsage(AttributeTargets.Method)]
    public class IpActionAttribute : Attribute, IAsyncActionFilter, ITransientDependency
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var address = context.HttpContext.Connection.RemoteIpAddress.ToString();
            if (address.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException("Action not Address!");
            }
            var _verifyPictureAppService = context.HttpContext.RequestServices.GetService(typeof(IIpActionAppService)) as IIpActionAppService;
            await _verifyPictureAppService.AddAsync(address);

        }
    }
}
