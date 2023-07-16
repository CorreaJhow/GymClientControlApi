using GymClientControl.Domain.Services.v1.Contracts;
using GymClientControl.Domain.Services.v1.Implementation;
using GymClientControl.Infrastructure.ImplementationPersistence.v1.Client;
using Microsoft.OpenApi.Models;
using Serilog;

namespace GymClientControl
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gym Client Control",
                    Version = "v1",
                    Description = "API responsible for controlling and managing gym clients",
                    Contact = new OpenApiContact
                    {
                        Name = "Jhonatas R Correa",
                        Url = new Uri("https://www.linkedin.com/in/jhonatas-r-correa/")
                    }
                });
            });

            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<IClientServicePersistence, ClientServicePersistence>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}