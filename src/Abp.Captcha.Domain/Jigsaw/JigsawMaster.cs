using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities.Auditing;

namespace Abp.Captcha.Jigsaw
{
    /// <summary>
    /// 拼图信息类
    /// </summary>
    public class JigsawMaster : CreationAuditedEntity<int>
    {
        /// <summary>
        /// 滑动运动线性
        /// </summary>
        public int Linear { get; set; }

        /// <summary>
        /// 是否通过验证
        /// </summary>
        public bool Validated { get; set; }
    }
}
