using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopAction.Application;
using ShopAction.Infrastructure;

namespace ShopAction.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddInfrastructure(Configuration);
            services.AddApplication();
            services.AddSwaggerDocument(
               config =>
                   config.PostProcess = document =>
                   {
                       document.Info.Version = "v1";
                       document.Info.Title = "Learning CQRS API";
                       document.Info.Description = "A simple solution to test api for asp.net core";
                       document.Info.Contact = new NSwag.OpenApiContact
                       {
                           Name = "Huynh Minh Trung",
                           Email = "huynh.trung140495@outlook.com",
                           Url = string.Empty
                       };
                   }
               );
            services.AddCors(x => x.AddPolicy("EnableCors", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();
            app.UseCors("EnableCors");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
