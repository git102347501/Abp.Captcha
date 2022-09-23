using MaigcalConch.Abp.Captcha.Slider;
using MaigcalConch.Abp.Captcha.UserAction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace MagicalConch.Abp.Captcha.UserAction
{
    public interface IUserActionManager : IDomainService
    {
        /// <summary>
        /// Add
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task AddAsync(UserActionMaster data);

        /// <summary>
        /// 根据用户会话信息，返回人机验证方式和验证数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserActionVerificationModel> GetVerificationModeAsync(Guid? userId, ValidationModel<string> input);
    }
}
