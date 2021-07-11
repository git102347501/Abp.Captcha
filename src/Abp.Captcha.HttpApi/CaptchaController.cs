using MaigcalConch.Abp.Captcha.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MaigcalConch.Abp.Captcha
{
    public abstract class CaptchaController : AbpController
    {
        protected CaptchaController()
        {
            LocalizationResource = typeof(CaptchaResource);
        }
    }
}
