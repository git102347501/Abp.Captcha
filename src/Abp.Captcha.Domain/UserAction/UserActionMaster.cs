using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace MaigcalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// 用户行为聚合
    /// </summary>
    public class UserActionMaster : CreationAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 设备
        /// </summary>
        public string Device { get; set; }
    }
}
