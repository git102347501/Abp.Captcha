using System;
using MagicalConch.Abp.Captcha.IP;
using MaigcalConch.Abp.Captcha.UserAction;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MaigcalConch.Abp.Captcha.EntityFrameworkCore
{
    public static class CaptchaDbContextModelCreatingExtensions
    {
        public static void ConfigureCaptcha(
            this ModelBuilder builder,
            Action<CaptchaModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CaptchaModelBuilderConfigurationOptions(
                CaptchaDbProperties.DbTablePrefix,
                CaptchaDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            builder.Entity<UserActionMaster>(b =>
            {
                b.ConfigureByConvention();
                b.Property(q => q.Ip).HasMaxLength(128);
                b.Property(q => q.Path).HasMaxLength(128);
                b.Property(q => q.Country).HasMaxLength(48);
                b.Property(q => q.Province).HasMaxLength(48);
                b.Property(q => q.City).HasMaxLength(48);
                b.Property(q => q.Area).HasMaxLength(128);
                b.Property(q => q.DeviceName).HasMaxLength(68);
            });

            builder.Entity<IPMaster>(b =>
            {
                b.ConfigureByConvention();
                b.Property(q => q.Ip).HasMaxLength(128);
            });
        }
    }
}