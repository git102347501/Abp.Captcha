using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace Abp.Captcha
{
    [DependsOn(
        typeof(CaptchaHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CaptchaConsoleApiClientModule : AbpModule
    {
        
    }
}
