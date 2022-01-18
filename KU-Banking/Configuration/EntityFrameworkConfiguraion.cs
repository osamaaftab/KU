using Context;
using DBContext.Data;
using Microsoft.EntityFrameworkCore;

namespace KU_Banking.Configuration {
    public class EntityFrameworkConfiguraion {
        /// <summary>
        /// Configures the service.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        public static void ConfigureService(IServiceCollection services) {
            // Entity framework configuration
            services.AddDbContext<BankContext>(options =>
                options.UseSqlServer("Server=tcp:ku-bank-assignment.database.windows.net,1433;Initial Catalog=Banking;Persist Security Info=False;User ID=osama-admin;Password=Crazier!23;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddScoped<IDbContext, BankContext>();
        }
    }
}
