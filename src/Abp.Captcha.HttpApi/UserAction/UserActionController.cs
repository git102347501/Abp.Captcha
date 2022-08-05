﻿using MagicalConch.Abp.Captcha.UserAction.Dtos;
using MaigcalConch.Abp.Captcha;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction
{
    public class UserActionController : CaptchaController
    {
        private readonly IUserActionAppService _userActionAppService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserActionController(IUserActionAppService userActionAppService, IHttpContextAccessor httpContextAccessor)
        {
            _userActionAppService = userActionAppService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserActionVerificationModel> GetVerificationModeAsync()
        {
            var ip = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            return await _userActionAppService.GetVerificationModeAsync(new GetVerificationModeInput()
            {
                Ip = ip
            });
        }
    }
}
