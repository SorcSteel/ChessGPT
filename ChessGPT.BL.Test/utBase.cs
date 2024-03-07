using ChessGPT.PL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ChessGPT.BL.Test
{
    [TestClass]
    public abstract class utBase
    {
        protected ChessGPTEntities dc;
        protected IDbContextTransaction transaction;
        private IConfigurationRoot _configuration;

        // represent the database configuration
        protected DbContextOptions<ChessGPTEntities> options;

        public utBase()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _configuration = builder.Build();

            options = new DbContextOptionsBuilder<ChessGPTEntities>()
                .UseSqlServer(_configuration.GetConnectionString("DatabaseConnection"))
                .UseLazyLoadingProxies()
                .Options;

            dc = new ChessGPTEntities(options);
        }

    }
}
