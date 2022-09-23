using MagicalConch.Abp.Captcha.UserAction.Dtos;
using MaigcalConch.Abp.Captcha;
using MaigcalConch.Abp.Captcha.Slider;
using MaigcalConch.Abp.Captcha.UserAction;
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
            return await _userActionManager.GetVerificationModeAsync(CurrentUser.Id, input);
        }

        public async Task AddAsync(string ipv4, string ipv6, string device, int deviceType)
        {
            await _userActionManager.AddAsync(new UserActionMaster(ipv4, ipv6, device, CurrentUser.Id));
        }
    }
}
