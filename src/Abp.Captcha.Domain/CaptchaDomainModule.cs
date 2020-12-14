using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Abp.Captcha
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(CaptchaDomainSharedModule)
    )]
    public class CaptchaDomainModule : AbpModule
    {

    }
}
