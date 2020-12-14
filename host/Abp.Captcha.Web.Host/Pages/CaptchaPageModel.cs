using Abp.Captcha.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.Captcha.Pages
{
    public abstract class CaptchaPageModel : AbpPageModel
    {
        protected CaptchaPageModel()
        {
            LocalizationResourceType = typeof(CaptchaResource);
        }
    }
}