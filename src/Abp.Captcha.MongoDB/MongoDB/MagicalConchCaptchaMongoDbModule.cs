using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace MaigcalConch.Abp.Captcha.MongoDB
{
    [DependsOn(
        typeof(MagicalConchCaptchaDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class MagicalConchCaptchaMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<MagicalConchCaptchaMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
