using AwwDTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aww_Api_Repository
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<AwwCategoryDT> Categories { get; set; }
        public DbSet<AwwDT> AwwImages { get; set; }
        public DbSet<ApiUrlDTO> ApiUrls { get; set; }
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options):base(options) { }
        private static IConfigurationRoot _configuration;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                _configuration = builder.Build();
                string cnstr = _configuration.GetConnectionString("StringyConnections");
                optionsBuilder.UseSqlServer(cnstr);
            }
        }
    }
}
