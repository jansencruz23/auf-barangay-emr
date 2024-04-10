using AUF.EMR.Application.Contracts.Persistence;
using AUF.EMR.Application.Contracts.Persistence.Common;
using AUF.EMR.Persistence.Repositories;
using AUF.EMR.Persistence.Repositories.Common;
using AUF.EMR.Persistence.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EMRDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IHouseholdRepository, HouseholdRepository>();
            services.AddScoped<IHouseholdMemberRepository, HouseholdMemberRepository>();
            services.AddScoped<IMasterlistRepository, MasterlistRepository>();
            services.AddScoped<IOralHealthRepository, OralHealthRepository>();
            services.AddScoped<IWRARepository, WRARepository>();
            services.AddScoped<IPregnancyTrackingRepository, PregnancyTrackingRepository>();
            services.AddScoped<IBarangayRepository, BarangayRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<IRecordRepository, RecordRepository>();

            services.AddScoped<AdminSeeder>();
            services.AddScoped<BarangaySeeder>();

            return services;
        }
    }
}
