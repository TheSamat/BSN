using Microsoft.OpenApi.Models;
using Xunit;

namespace BSN.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(setup => setup.SwaggerDoc("v1", new OpenApiInfo()
            {
                Description = "Pet Project for learning Web API on .NET 7",
                Title = "BSN - Boring Social Network",
                Version = "v1",
                Contact = new OpenApiContact()
                {
                    Name = "BSN",
                    Url = new Uri("https://github.com/TheSamat/BSN")
                }
            }));

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.Run();
        }
    }
}




