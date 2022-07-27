using MagicalConch.Abp.Captcha.UserAction.Dtos;
using MaigcalConch.Abp.Captcha;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace MagicalConch.Abp.Captcha.UserAction
{
    public class UserActionAppService : CaptchaAppService, IUserActionAppService
    {
        private readonly IUserActionManager _userActionManager;

        public UserActionAppService(IUserActionManager userActionManager)
        {
            _userActionManager = userActionManager;
        }

        public async Task<UserActionVerificationModel> GetVerificationModeAsync(GetVerificationModeInput input)
        {
            return _userActionManager.GetAppraise();
        }
    }
}
