using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace MaigcalConch.Abp.Captcha.MongoDB
{
    [ConnectionStringName(CaptchaDbProperties.ConnectionStringName)]
    public class MagicalConchCaptchaMongoDbContext : AbpMongoDbContext, IMagicalConchCaptchaMongoDbContext
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