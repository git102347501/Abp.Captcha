using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Abp.Captcha.MongoDB
{
    [ConnectionStringName(CaptchaDbProperties.ConnectionStringName)]
    public class CaptchaMongoDbContext : AbpMongoDbContext, ICaptchaMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureCaptcha();
        }
    }
}