using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace MaigcalConch.Abp.Captcha.MongoDB
{
    public static class MagicalConchCaptchaMongoDbContextExtensions
    {
        public static void ConfigureCaptcha(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new MagicalConchCaptchaMongoModelBuilderConfigurationOptions(
                CaptchaDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}