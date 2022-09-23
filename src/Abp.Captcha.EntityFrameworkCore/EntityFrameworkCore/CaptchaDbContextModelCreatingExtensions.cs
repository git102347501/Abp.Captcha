using System;
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
                //Properties
                b.Property(q => q.Ipv6).HasMaxLength(128);
                b.Property(q => q.Ipv4).HasMaxLength(32);
                b.Property(q => q.Country).HasMaxLength(48);
                b.Property(q => q.Province).HasMaxLength(48);
                b.Property(q => q.City).HasMaxLength(48);
                b.Property(q => q.Area).HasMaxLength(128);
                b.Property(q => q.Device).HasMaxLength(68);
            });
        }
    }
}