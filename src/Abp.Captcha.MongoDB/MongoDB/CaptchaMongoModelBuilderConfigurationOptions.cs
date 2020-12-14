using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace Abp.Captcha.MongoDB
{
    public class CaptchaMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public CaptchaMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}