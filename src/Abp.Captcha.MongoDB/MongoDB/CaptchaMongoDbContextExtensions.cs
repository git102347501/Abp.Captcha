using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace Abp.Captcha.MongoDB
{
    public static class CaptchaMongoDbContextExtensions
    {
        public static void ConfigureCaptcha(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CaptchaMongoModelBuilderConfigurationOptions(
                CaptchaDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}