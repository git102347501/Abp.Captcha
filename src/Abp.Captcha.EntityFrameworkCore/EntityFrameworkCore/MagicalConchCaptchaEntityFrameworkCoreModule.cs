using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MaigcalConch.Abp.Captcha.EntityFrameworkCore
{
    [DependsOn(
        typeof(MagicalConchCaptchaDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class MagicalConchCaptchaEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<CaptchaDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
            });
        }
    }
}