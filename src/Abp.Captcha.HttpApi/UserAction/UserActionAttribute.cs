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
    /// 会话安全审计特性
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class UserActionAttribute : Attribute, IAsyncActionFilter, ITransientDependency
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var actionType = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "ActionType");
            if (actionType.Key.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException("The verification data is wrong!");
            }
            var actionId = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "ActionId");
            if (actionId.Key.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException("The verification data is wrong!");
            }

            var type = (UserActionVerificationTypeEnum)Enum.Parse(typeof(UserActionVerificationTypeEnum), actionType.Key);
            if (!Enum.IsDefined(typeof(UserActionVerificationTypeEnum), type))
            {
                throw new UserFriendlyException("The verification data is wrong!");
            }

            await CheckActionAsync(context, new Guid(actionId.Key), type);

            await CheckTokenAsync(context, type, next);

            await AddActionHistoryAsync(context);
        }

        /// <summary>
        /// Add Action History
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task AddActionHistoryAsync(ActionExecutingContext context)
        {
            var _userActionAppService = context.HttpContext.RequestServices.GetService(typeof(IUserActionAppService)) as IUserActionAppService;
            // add action data
            await _userActionAppService.AddAsync(
                context.HttpContext.Connection.RemoteIpAddress.ToString(),
                context.HttpContext.Request.Path.ToString(),
                context.HttpContext.Request.Headers["User-Agent"].ToString());
        }

        /// <summary>
        /// Check Action 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        private async Task CheckActionAsync(ActionExecutingContext context, Guid id, UserActionVerificationTypeEnum type)
        {
            var userActionAppService = context.HttpContext.RequestServices.GetService(typeof(IUserActionAppService)) as IUserActionAppService;
            var checkActionRes = await userActionAppService.VerificationTokenAsync(id, type);
            if (!checkActionRes)
            {
                throw new UserFriendlyException("The verification data is wrong!");
            }
        }

        /// <summary>
        /// Check Token
        /// </summary>
        /// <param name="context"></param>
        /// <param name="type"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        private async Task CheckTokenAsync(ActionExecutingContext context, UserActionVerificationTypeEnum type, ActionExecutionDelegate next)
        {
            var data = context.HttpContext.Request.Headers.FirstOrDefault(c => c.Key == "Data");
            var actionData = new SliderActionModel(context.HttpContext.Connection.RemoteIpAddress.ToString(), context.HttpContext.Request.Headers["User-Agent"].ToString());

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
        }
    }
}
