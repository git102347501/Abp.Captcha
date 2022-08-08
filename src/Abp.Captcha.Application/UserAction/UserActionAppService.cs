using MagicalConch.Abp.Captcha.UserAction.Dtos;
using MaigcalConch.Abp.Captcha;
using MaigcalConch.Abp.Captcha.Slider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace MagicalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// 用户会话应用服务
    /// </summary>
    public class UserActionAppService : CaptchaAppService, IUserActionAppService
    {
        private readonly IUserActionManager _userActionManager;

        public UserActionAppService(IUserActionManager userActionManager)
        {
            _userActionManager = userActionManager;
        }

        public async Task<UserActionVerificationModel> GetVerificationModeAsync(ValidationModel<string> input)
        {
            return await _userActionManager.GetVerificationModeAsync(CurrentUser.Id.Value, input);
        }
    }
}
