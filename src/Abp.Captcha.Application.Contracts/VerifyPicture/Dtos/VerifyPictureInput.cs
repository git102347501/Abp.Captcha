using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace MaigcalConch.Abp.Captcha.VerifyPicture.Dtos
{
    /// <summary>
    /// 获取验证图片入参
    /// </summary>
    public class VerifyPictureInput : EntityDto
    {
        /// <summary>
        /// 验证码长度
        /// </summary>
        public int Length { get; set; }
    }
}
