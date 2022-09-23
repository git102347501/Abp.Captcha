using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace MaigcalConch.Abp.Captcha.UserAction
{
    /// <summary>
    /// 用户行为聚合
    /// </summary>
    public class UserActionMaster : CreationAuditedAggregateRoot<int>
    {
        /// <summary>
        /// UserId
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// IPv4地址
        /// </summary>
        public string Ipv4 { get; set; }

        /// <summary>
        /// IPv6地址
        /// </summary>
        public string Ipv6 { get; set; }

        /// <summary>
        /// Country
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Province
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Area
        /// </summary>
        public string Area { get; set; }

        /// <summary>
        /// 设备
        /// </summary>
        public string Device { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public int DeviceType { get; set; }

        public UserActionMaster(string ipv4, string ipv6, string country, string province, string city, string area, string device, int deviceType, Guid? userId = null)
        {
            Ipv4 = ipv4;
            Ipv6 = ipv6;
            Country = country;
            Province = province;
            City = city;
            Area = area;
            Device = device;
            DeviceType = deviceType;
            UserId = userId;
        }
    }
}
