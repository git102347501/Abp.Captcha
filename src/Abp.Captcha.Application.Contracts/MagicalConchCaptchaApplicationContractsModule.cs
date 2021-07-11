using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace MaigcalConch.Abp.Captcha
{
    [DependsOn(
        typeof(MagicalConchCaptchaDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class MagicalConchCaptchaApplicationContractsModule : AbpModule
    {

    }
}
