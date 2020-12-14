using Abp.Captcha.Localization;
using Volo.Abp.Application.Services;

namespace Abp.Captcha
{
    public abstract class CaptchaAppService : ApplicationService
    {
        protected CaptchaAppService()
        {
            LocalizationResource = typeof(CaptchaResource);
            ObjectMapperContext = typeof(CaptchaApplicationModule);
        }
    }
}
