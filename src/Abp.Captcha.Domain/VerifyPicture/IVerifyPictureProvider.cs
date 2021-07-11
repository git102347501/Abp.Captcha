using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MaigcalConch.Abp.Captcha.VerifyPicture
{
    /// <summary>
    /// 验证图片生成提供接口
    /// </summary>
    public interface IVerifyPictureProvider
    {
        /// <summary>
        /// 生成验证图片
        /// </summary>
        /// <returns></returns>
        Task<byte[]> GenerateAsync(string length);

        /// <summary>
        /// 生成指定位数验证码
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        string CreateCode(int num);
    }
}
