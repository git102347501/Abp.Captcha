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
        public Task<GetVerificationModeOutput> GetVerificationModeAsync(GetVerificationModeInput input)
        {
            throw new NotImplementedException();
        }
    }
}
