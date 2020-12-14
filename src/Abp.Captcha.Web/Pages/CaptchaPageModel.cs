using Abp.Captcha.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Abp.Captcha.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CaptchaPageModel : AbpPageModel
    {
        protected CaptchaPageModel()
        {
            LocalizationResourceType = typeof(CaptchaResource);
            ObjectMapperContext = typeof(CaptchaWebModule);
        }
    }
}