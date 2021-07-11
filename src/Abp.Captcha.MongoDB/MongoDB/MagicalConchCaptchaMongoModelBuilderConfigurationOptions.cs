using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace MaigcalConch.Abp.Captcha.MongoDB
{
    public class MagicalConchCaptchaMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public MagicalConchCaptchaMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}