using Data.DAL.Context;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Data.DAL.Repositories;

namespace PolyclinicBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void CoufigureAuth(IApplicationBuilder app) { }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("Polyclinic", new OpenApiInfo
                {
                    Title = "Polyclinic",
                    Version = "v2"
                });
                c.SwaggerDoc("Admin", new OpenApiInfo
                {
                    Title = "Admin",
                    Version = "v2"
                });
                c.SwaggerDoc("Login", new OpenApiInfo
                {
                    Title = "Login",
                    Version = "v2"
                });
            });

            services.AddDbContext<PolyclinicContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DataConnection")));
            services.AddTransient<VisitorRepository>();
            services.AddTransient<RecordRepository>();
            services.AddTransient<SurveyRepository>();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/Polyclinic/swagger.json", "Polyclinic");
                c.SwaggerEndpoint("/swagger/Admin/swagger.json", "Admin");
                c.SwaggerEndpoint("/swagger/Login/swagger.json", "Login");
            });
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
