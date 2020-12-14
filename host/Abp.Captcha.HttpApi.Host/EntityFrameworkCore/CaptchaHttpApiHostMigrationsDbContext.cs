using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Abp.Captcha.EntityFrameworkCore
{
    public class CaptchaHttpApiHostMigrationsDbContext : AbpDbContext<CaptchaHttpApiHostMigrationsDbContext>
    {
        public CaptchaHttpApiHostMigrationsDbContext(DbContextOptions<CaptchaHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureCaptcha();
        }
    }
}
