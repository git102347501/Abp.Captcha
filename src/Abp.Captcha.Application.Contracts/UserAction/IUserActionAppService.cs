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
        Task<UserActionVerificationModel> GetVerificationModeAsync(ValidationModel<string> input);

        Task AddAsync(string ipv4, string path, string device);

        Task<bool> VerificationTokenAsync(Guid id, UserActionVerificationTypeEnum type);
    }
}
