using Microsoft.Extensions.DependencyInjection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Xunit;
using BSN.WebApi.Infrastructure;
using AutoMapper;
using BSN.WebApi.Domain;
using BSN.WebApi.Features;
using AutoMapper.Features;

var builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<IDbContext, TestDbContext>();
}
else
{
    //builder.Services.AddDbContext<IDbContext, OtherDbContext>();
}

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
AutoMapperConfig.Configure();

builder.Services.AddControllers();
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


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
