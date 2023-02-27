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
        Task AddAsync(string ip, string path, string deviceName, Guid? userId = null);

        /// <summary>
        /// 根据用户会话信息，返回人机验证方式和验证数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<UserActionVerificationModel> GetVerificationModeAsync(Guid? userId, ValidationModel<string> input);

        /// <summary>
        /// 验证会话有效
        /// </summary>
        /// <param name="id"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<bool> VerificationTokenAsync(Guid id, UserActionVerificationTypeEnum type);
    }
}
