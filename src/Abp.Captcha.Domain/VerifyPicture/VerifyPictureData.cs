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

        public DateTime? TermValidityDate { get; set; }

        public VerifyPictureData(string index, string code, DateTime? termValidityDate = null)
        {
            this.Index = index;
            this.Code = code;
            this.TermValidityDate = termValidityDate;
        }

        /// <summary>
        /// 是否未过期
        /// </summary>
        /// <returns></returns>
        private bool IsUnexpired()
        {
            return this.TermValidityDate == null ? true : this.TermValidityDate <= DateTime.Now;
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        /// <param name="code">验证码</param>
        /// <returns></returns>
        public bool IsValid(string code)
        {
            if (this.IsUnexpired())
            {
                return this.Code == code;
            }
            else {
                return false;
            }
        }
    }
}
