using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MaigcalConch.Abp.Captcha.EntityFrameworkCore
{
    public class CaptchaModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public CaptchaModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}