using KU_Banking.Configuration;
using Microsoft.AspNetCore.Diagnostics;

namespace KU_Banking {
    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc().AddControllersAsServices();
            services.AddAutoMapper(typeof(MappingProfile));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();

            EntityFrameworkConfiguraion.ConfigureService(services);
            IocContainerConfiguration.ConfigureService(services, Configuration);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app) {
           
                app.UseSwagger();
                app.UseSwaggerUI();
            


            app.UseHttpsRedirection();

          
            app.UseRouting();

            app.UseAuthorization();
            app.UseEndpoints(endpoints => {endpoints.MapControllers();});  
        }
    }
}
