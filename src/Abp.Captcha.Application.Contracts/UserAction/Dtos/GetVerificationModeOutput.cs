using System;
using System.Collections.Generic;
using System.Text;

namespace MagicalConch.Abp.Captcha.UserAction.Dtos
{
    public class GetVerificationModeOutput
    {
        /// <summary>
        /// 验证方式
        /// </summary>
        public int Type { get; set; }

        public string Data { get; set; }
    }
}
