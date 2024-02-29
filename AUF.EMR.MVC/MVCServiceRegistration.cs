using System.Reflection;

namespace AUF.EMR.MVC
{
    public static class MVCServiceRegistration
    {
        public static IServiceCollection ConfigureMVCService(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
