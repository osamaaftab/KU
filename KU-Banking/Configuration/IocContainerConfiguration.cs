using Common.Data;
using Common.Model;
using KU_Banking.Services;
using KU_Banking.Services.Imp;
using KU_Banking.Services.Interface;

namespace KU_Banking.Configuration {
    public static class IocContainerConfiguration {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services, IConfiguration configuration) {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAPIResponse, ApiResponse>();
            services.AddTransient<IContextFactory, ContextFactory>();
            services.AddTransient<IUnitofWork, UnitofWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IAccountServices, AccountServices>();
            services.AddTransient<ICustomerServices, CustomerServices>();



        }
    }
}
