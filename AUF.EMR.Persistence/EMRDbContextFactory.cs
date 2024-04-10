using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence
{
    public class EMRDbContextFactory : IDesignTimeDbContextFactory<EMRDbContext>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EMRDbContextFactory()
        {

        }

        public EMRDbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public EMRDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<EMRDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

            return new EMRDbContext(builder.Options, _httpContextAccessor);
        }
    }
}
