using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

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

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
        }
    }
}