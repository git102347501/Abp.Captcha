using MaigcalConch.Abp.Captcha.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MaigcalConch.Abp.Captcha
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(CaptchaEntityFrameworkCoreTestModule)
        )]
    public class CaptchaDomainTestModule : AbpModule
    {
        
    }
}
