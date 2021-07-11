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
        public string Ip { get; set; }
    }
}
