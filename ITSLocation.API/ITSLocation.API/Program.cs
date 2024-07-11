using ITSLocation.Application.Interfaces;
using ITSLocation.Application.Services;
using ITSLocation.Domain.RepositoryInterfaces;
using ITSLocation.Infrastructure.Repository;
using log4net.Config;
using log4net.Repository;
using log4net;
using Microsoft.OpenApi.Models;
using System.IO;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace ITSLocation.API
{
    public class Program
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Program));
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<ILocationService, LocationService>();

            // Registrar log4net logger
            builder.Services.AddSingleton(LogManager.GetLogger(typeof(Program)));

            builder.Services.AddControllers();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ITSLocation API", Version = "v1" });
            });

            // Configure log4net
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));


            log.Info("log4net configurado correctamente en Program.cs"); // Línea de prueba


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ITSLocation API v1"));
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
