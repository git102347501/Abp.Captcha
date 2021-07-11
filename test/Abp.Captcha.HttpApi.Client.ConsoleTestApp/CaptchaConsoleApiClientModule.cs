using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace MaigcalConch.Abp.Captcha
{
    [DependsOn(
        typeof(MagicalConchCaptchaHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CaptchaConsoleApiClientModule : AbpModule
    {
        
    }
}
