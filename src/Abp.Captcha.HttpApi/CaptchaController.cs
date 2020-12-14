using Abp.Captcha.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Abp.Captcha
{
    public abstract class CaptchaController : AbpController
    {
        protected CaptchaController()
        {
            LocalizationResource = typeof(CaptchaResource);
        }
    }
}
