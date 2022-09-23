using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace MagicalConch.Abp.Captcha.IP
{
    /// <summary>
    /// IP Aggregate
    /// </summary>
    public class IPMaster : AggregateRoot<int>, IHasCreationTime, IMultiTenant
    {
        public string Ip { get; set; }

        public IPTypeEnum Type { get; set; }

        public IPCategoryEnum Category { get; set; }

        public DateTime CreationTime { get; set; }

        public Guid? TenantId { get; set; }

        public IPMaster(string ip, IPTypeEnum type, IPCategoryEnum category)
        {
            Ip = ip;
            Type = type;
            Category = category;
            CreationTime = DateTime.Now;
        }
    }
}
