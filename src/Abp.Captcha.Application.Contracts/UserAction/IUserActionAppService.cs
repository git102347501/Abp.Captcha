using MagicalConch.Abp.Captcha.UserAction.Dtos;
using MaigcalConch.Abp.Captcha.Slider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace MagicalConch.Abp.Captcha.UserAction
{
    public interface IUserActionAppService : IApplicationService
    {
        Task<UserActionVerificationModel> GetVerificationModeAsync(GetVerificationModeInput input);
    }
}
