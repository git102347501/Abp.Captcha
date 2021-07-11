using Volo.Abp.Modularity;

namespace MaigcalConch.Abp.Captcha
{
    [DependsOn(
        typeof(MagicalConchCaptchaApplicationModule),
        typeof(CaptchaDomainTestModule)
        )]
    public class CaptchaApplicationTestModule : AbpModule
    {

    }
}
