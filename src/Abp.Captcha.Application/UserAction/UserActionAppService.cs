using MagicalConch.Abp.Captcha.UserAction.Dtos;
using MaigcalConch.Abp.Captcha;
using MaigcalConch.Abp.Captcha.Slider;
using MaigcalConch.Abp.Captcha.UserAction;
using System;
using System.Collections.Generic;
using System.IO;
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

        /// <summary>
        /// Add Action Data
        /// </summary>
        /// <param name="ipv4"></param>
        /// <param name="path"></param>
        /// <param name="device"></param>
        /// <param name="deviceType"></param>
        /// <returns></returns>
        public async Task AddAsync(string ipv4, string path, string device)
        {
            await _userActionManager.AddAsync(ipv4, path, device, CurrentUser.Id);
        }

        /// <summary>
        /// 验证滑条是否有效
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<bool> VerificationTokenAsync(Guid id, UserActionVerificationTypeEnum type)
        {
            return await _userActionManager.VerificationTokenAsync(id, type);
        }
    }
}
