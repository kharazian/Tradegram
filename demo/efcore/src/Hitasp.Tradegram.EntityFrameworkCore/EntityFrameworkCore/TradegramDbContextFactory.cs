using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Hitasp.Tradegram.EntityFrameworkCore
{
    public class TradegramDbContextFactory : IDesignTimeDbContextFactory<TradegramDbContext>
    {
        public TradegramDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TradegramDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Default"));

            return new TradegramDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Hitasp.Tradegram.Web/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
