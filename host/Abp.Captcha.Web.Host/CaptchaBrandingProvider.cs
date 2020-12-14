using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Abp.Captcha
{
    [Dependency(ReplaceServices = true)]
    public class CaptchaBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Captcha";
    }
}
