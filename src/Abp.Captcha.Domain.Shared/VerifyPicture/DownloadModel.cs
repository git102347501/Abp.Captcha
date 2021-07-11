using System;
using System.Collections.Generic;
using System.Text;

namespace MaigcalConch.Abp.Captcha.VerifyPicture
{
    /// <summary>
    /// 图形验证码信息下载模型
    /// </summary>
    public class DownloadModel
    {
        /// <summary>
        /// 图像索引
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// 图像内容
        /// </summary>
        public byte[] Content { get; set; }

        public DownloadModel(string index, byte[] content)
        {
            this.Index = index;
            this.Content = content;
        }
    } 
}
