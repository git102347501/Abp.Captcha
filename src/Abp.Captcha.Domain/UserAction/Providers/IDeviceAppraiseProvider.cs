using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MagicalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// 设备安全模型评估
    /// </summary>
    public interface IDeviceAppraiseProvider
    {
        /// <summary>
        /// GetGrade
        /// </summary>
        /// <returns></returns>
        public Task<int> GetGrade(Guid userId, string deviceName);
    }
}
