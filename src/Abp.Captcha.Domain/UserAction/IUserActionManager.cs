using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction
{
    internal interface IUserActionManager
    {
        /// <summary>
        /// 评估用户行为模型
        /// </summary>
        /// <returns></returns>
        Task<UserActionAppraise> GetAppraise();
    }
}
