using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Abp.Captcha.EntityFrameworkCore
{
    public class CaptchaHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CaptchaHttpApiHostMigrationsDbContext>
    {
        public CaptchaHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CaptchaHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Captcha"));

            return new CaptchaHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
