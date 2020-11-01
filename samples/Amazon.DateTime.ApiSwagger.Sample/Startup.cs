using Amazon.DateTime.Serialization;
using Hein.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon.DateTime.ApiSwagger.Sample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new Info
                {
                    Title = " Amazon.DateTime.ApiSwagger.Sample",
                });

                //x.MapType<DateTimeBase>(() => new Microsoft.OpenApi.Models.OpenApiSchema { Type = "string", Format = "date-time" });
                x.AddGithubRepository("https://github.com/brandonhein/Amazon.DateTime");
                x.EnableAnnotations();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseTiming();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Amazon.DateTime.ApiSwagger.Sample");
                c.DisplayRequestDuration();
                c.DocumentTitle = "Swagger";
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
