using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace MaigcalConch.Abp.Captcha
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AbpCachingModule),
        typeof(MagicalConchCaptchaDomainSharedModule),
        typeof(AbpCachingModule)
    )]
    public class MagicalConchCaptchaDomainModule : AbpModule
    {

    }
}
