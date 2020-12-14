using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Abp.Captcha
{
    [DependsOn(
        typeof(CaptchaDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class CaptchaApplicationContractsModule : AbpModule
    {

    }
}
