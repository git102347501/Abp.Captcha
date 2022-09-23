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
        /// Path
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// IPv4地址
        /// </summary>
        public string Ip { get; set; }

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
        public string DeviceName { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public int DeviceType { get; set; }

        public UserActionMaster(string ip, string path, string deviceName, Guid? userId = null)
        {
            Ip = ip;
            Path = path;
            DeviceName = deviceName;
            UserId = userId;
        }
    }
}
