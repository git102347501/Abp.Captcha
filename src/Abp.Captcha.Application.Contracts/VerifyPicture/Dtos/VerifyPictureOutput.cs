using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Abp.Captcha.VerifyPicture.Dtos
{
    /// <summary>
    /// 获取验证图片出参
    /// </summary>
    public class VerifyPictureOutput: EntityDto
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// 图片内容
        /// </summary>
        public string Content { get; set; }
    }
}
