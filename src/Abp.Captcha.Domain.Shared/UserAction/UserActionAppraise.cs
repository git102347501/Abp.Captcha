using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// 用户行为评估结果
    /// </summary>
    public class UserActionAppraise
    {
        public int IPGrade { get; set; }

        public int DeviceGrade { get; set; }

        public int AverageGrade { get { return (this.IPGrade + this.DeviceGrade) / 2; } }
    }
}
