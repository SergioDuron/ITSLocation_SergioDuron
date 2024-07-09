using ITSLocation.Application.Interfaces;
using ITSLocation.Application.Services;
using ITSLocation.Domain.RepositoryInterfaces;
using ITSLocation.Infrastructure.Repository;
using log4net.Config;
using log4net.Repository;
using log4net;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ITSLocation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar log4net
            ILoggerRepository logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));


            // Add services to the container.
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<ILocationService, LocationService>();

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ITSLocation API", Version = "v1" });
            });




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                // Enable middleware to serve Swagger-UI (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ITSLocation API v1"));

            }
            // Configura el pipeline de solicitudes HTTP.
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }


    }
}