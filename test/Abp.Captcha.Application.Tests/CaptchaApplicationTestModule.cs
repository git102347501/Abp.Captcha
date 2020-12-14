using Volo.Abp.Modularity;

namespace Abp.Captcha
{
    [DependsOn(
        typeof(CaptchaApplicationModule),
        typeof(CaptchaDomainTestModule)
        )]
    public class CaptchaApplicationTestModule : AbpModule
    {

    }
}
