using AuthService.Application.Commands.Register;
using AuthService.Application.Dtos;
using AuthService.Application.Interfaces;
using AuthService.Application.Validators;
using AuthService.Infrastructure.Auth;
using AuthService.Infrastructure.DbContext;
using AuthService.Infrastructure.Redis;
using AuthService.Infrastructure.Repositories;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Unifrik.Infrastructure.Shared.Configuration;
using Unifrik.Infrastructure.Shared.Database.Infrastructure;
using Unifrik.Infrastructure.Shared.Database.Interfaces;
using Unifrik.Infrastructure.Shared.Middlewares;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    DotNetEnv.Env.Load(); 
}
builder.Configuration.AddEnvironmentVariables();


// Add services to the container.
builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("User"))
);



builder.Services
    .AddIdentity<AuthService.Domain.Entities.User, IdentityRole>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork<UserDbContext>>();
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(RegisterBuyerDto).Assembly));

builder.Services.AddAutoMapper(typeof(RegisterBuyerDto).Assembly);


builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
     });
builder.Services.AddFluentValidationAutoValidation();
builder.Services
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IUserServices, UserServices>()
    .AddScoped<IAuthTokenService, AuthTokenService>()
    .AddSingleton(new RedisService(builder.Configuration["Redis_Configuration"]!));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;
builder.Services.AddSharedServices(configuration);
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<UserDbContext>();
    db.Database.Migrate(); 
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHealthChecks("/api/health");
app.UseMiddleware<GetCurrentUserMiddleware>();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
