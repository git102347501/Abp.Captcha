using System;
using System.Collections.Generic;
using System.Text;

namespace Abp.Captcha.VerifyPicture
{
    /// <summary>
    /// 图片验证码缓存信息类
    /// </summary>
    public class VerifyPictureData
    {
        public string Index { get; set; }

        public string Code { get; set; }

        public double? TermValidityMinutes { get; set; }

        public VerifyPictureData(string index, string code, double? termValidityMinutes = null)
        {
            this.Index = index;
            this.Code = code;
            this.TermValidityMinutes = termValidityMinutes;
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        /// <param name="code">验证码</param>
        /// <param name="ignored">是否忽略大小写</param>
        /// <returns></returns>
        public bool IsValid(string code, bool ignored = true)
        {
            return ignored ? this.Code.ToUpper() == code.ToUpper() : this.Code == code;
        }
    }
}
