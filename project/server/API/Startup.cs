using Application.Projects;
using Persistence;
using API.Middleware;
using Domain;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            System.Diagnostics.Debug.WriteLine("This is a log2");
        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseLazyLoadingProxies();
                opt.UseSqlite(Configuration.GetConnectionString("SQLLiteConnection"));
            });

            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            
            // services.AddDbContext<DataContext>(opt => 
            // {
            //     opt.UseLazyLoadingProxies();
            //     opt.UseMySql(
            //         Configuration.GetConnectionString("MySQLConnection"),
            //         new MySqlServerVersion(new Version(8, 0, 21))
            //     );
            // });

            // ConfigureServices(services);
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseLazyLoadingProxies();
                opt.UseSqlite(Configuration.GetConnectionString("SQLLiteConnection"));
            });

            ConfigureServices(services);
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("MyPolicy", policy => 
                {
                    policy
                        // .WithOrigins("http://localhost:3000")
                        // .AllowCredentials()
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
            services.AddMediatR(typeof(Details.Handler).Assembly);
            services.AddMediatR(typeof(Application.Projects.List.Handler).Assembly);
            services.AddAutoMapper(typeof(List.Handler));   
            services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            if (env.IsDevelopment())
            {
                // throw new Exception("Development mode");
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseXContentTypeOptions();
            app.UseReferrerPolicy(opt => opt.NoReferrer());
            app.UseXXssProtection(opt => opt.EnabledWithBlockMode());
            app.UseXfo(opt => opt.Deny());
            app.UseCsp(opt => opt
                .BlockAllMixedContent()
                .FormActions(s => s.Self())
                .FrameAncestors(s => s.Self())
            );

            // atm my frontend is separated
            // app.UseDefaultFiles();
            // app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("MyPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
