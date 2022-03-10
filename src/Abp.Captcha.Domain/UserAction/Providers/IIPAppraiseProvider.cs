using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// IP安全模型评估
    /// </summary>
    public interface IIPAppraiseProvider
    {
        /// <summary>
        /// GetGrade
        /// </summary>
        /// <returns></returns>
        public Task<int> GetGrade();
    }
}
