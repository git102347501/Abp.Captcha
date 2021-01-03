using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Captcha.VerifyPicture
{
    /// <summary>
    /// 图形验证码领域服务
    /// </summary>
    public interface IVerifyPictureManager
    {
        /// <summary>
        /// 创建图形验证码
        /// </summary>
        /// <returns></returns>
        Task<DownloadModel> CreateAsync(int length);

        /// <summary>
        /// 验证图形验证码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<bool> Validation(ValidationModel data);
    }
}
