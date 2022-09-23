using MaigcalConch.Abp.Captcha.Slider;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp;
using MaigcalConch.Abp.Captcha.VerifyPicture;
using Microsoft.AspNetCore.Http;

namespace MagicalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// 滑条验证特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class UserActionAttribute : Attribute, IAsyncActionFilter, ITransientDependency
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var data = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Data");

            var actionData = new SliderActionModel(context.HttpContext.Connection.RemoteIpAddress.ToString(),
                context.HttpContext.Request.Headers["User-Agent"].ToString());

            var actionType = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "ActionType");
            if (actionType.Key.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException("The verification data is wrong!");
            }
            var type = (UserActionVerificationTypeEnum)int.Parse(actionType.Key);
            switch (type)
            {
                case UserActionVerificationTypeEnum.VerifyPicture:
                    var imgdata = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "ImgValue");
                    var index = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "ImgIndex");

                    if (index.Key.IsNullOrWhiteSpace() || data.Key.IsNullOrWhiteSpace())
                    {
                        throw new UserFriendlyException("The verification data is not valid!");
                    }

                    var _verifyPictureAppService = context.HttpContext.RequestServices.GetService(typeof(IVerifyPictureAppService)) as IVerifyPictureAppService;
                    if (!await _verifyPictureAppService.ValidationAsync(new ValidationModel(index.Value, imgdata.Value)))
                    {
                        throw new UserFriendlyException("The verification data is wrong!");
                    }
                    await next();
                    break;
                case UserActionVerificationTypeEnum.Jigsaw:
                    break;
                case UserActionVerificationTypeEnum.Slider:
                    var _sliderAppService = context.HttpContext.RequestServices.GetService(typeof(ISliderAppService)) as ISliderAppService;
                    if (data.Key.IsNullOrWhiteSpace())
                    {
                        var token = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Token");
                        if (token.Key.IsNullOrWhiteSpace())
                        {
                            var valTokendata = new ValidationModel<string>(token.Value, actionData);
                            if (!await _sliderAppService.VerificationTokenAsync(valTokendata))
                            {
                                throw new UserFriendlyException("The verification data is wrong!");
                            }
                        }
                        throw new UserFriendlyException("The verification data is not valid!");
                    }

                    var valdata = new ValidationModel<int[]>(Array.ConvertAll(data.Value.ToString().Split(','), int.Parse), actionData);
                    if (!await _sliderAppService.VerificationAsync(valdata))
                    {
                        throw new UserFriendlyException("The verification data is wrong!");
                    }
                    await next();
                    break;
                case UserActionVerificationTypeEnum.UnAuth:
                    await next();
                    break;
                default:
                    throw new UserFriendlyException("The verification data is wrong!");
            }
            var _userActionAppService = context.HttpContext.RequestServices.GetService(typeof(IUserActionAppService)) as IUserActionAppService;
            // add action data
            await _userActionAppService.AddAsync(context.HttpContext.Connection.RemoteIpAddress.ToString(), "",
                context.HttpContext.Request.Headers["User-Agent"].ToString());
        }
    }
}
