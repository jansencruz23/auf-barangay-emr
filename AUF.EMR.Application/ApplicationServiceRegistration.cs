using AUF.EMR.Application.Contracts.Services;
using AUF.EMR.Application.Contracts.Services.Common;
using AUF.EMR.Application.Services;
using AUF.EMR.Application.Services.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IHouseHoldService, HouseHoldService>();
            services.AddScoped<IHouseHoldMemberService, HouseHoldMemberService>();

            return services;
        }
    }
}
