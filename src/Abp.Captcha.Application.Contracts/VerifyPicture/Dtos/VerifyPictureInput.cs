using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Range(4,20)]
        public int Length { get; set; }
    }
}
