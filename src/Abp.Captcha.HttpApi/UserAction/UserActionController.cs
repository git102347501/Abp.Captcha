using MagicalConch.Abp.Captcha.UserAction.Dtos;
using MaigcalConch.Abp.Captcha;
using MaigcalConch.Abp.Captcha.Slider;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// 用户会话
    /// </summary>
    public class UserActionController : CaptchaController
    {
        private readonly IUserActionAppService _userActionAppService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserActionController(IUserActionAppService userActionAppService, IHttpContextAccessor httpContextAccessor)
        {
            _userActionAppService = userActionAppService;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// 获取当前会话验证数据
        /// </summary>
        /// <returns></returns>
        public async Task<UserActionVerificationModel> GetVerificationModeAsync()
        {
            var actionData = new ValidationModel<string>(
                httpContextAccessor.HttpContext.Request.Path.ToString(), 
                new SliderActionModel(httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString(),
                httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString()));

            return await _userActionAppService.GetVerificationModeAsync(actionData);
        }
    }
}
