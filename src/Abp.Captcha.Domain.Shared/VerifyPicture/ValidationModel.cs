using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Captcha.VerifyPicture
{
    /// <summary>
    /// 图像验证信息模型
    /// </summary>
    public class ValidationModel
    {
        /// <summary>
        /// 图像索引
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
    }
}
