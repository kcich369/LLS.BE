using LLS.Api;
using LLS.Database.Context;
using LLS.Database.Extensions;
using LLS.Database.IdentityModels;
using LLS.Domain.Configurations;
using LLS.Infrastructure;
using LLS.Infrastructure.Extensions;
using LLS.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("oauth2",new OpenApiSecurityScheme()
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    opt.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddDbContext<LlsIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LlsIdentityDb")));

builder.Services
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<LlsIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddConfigSingleton<JwtConfiguration>(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration.BindSection<JwtConfiguration>()).AddAuthorization();

builder.Services.RegisterInfrastructure(builder.Configuration)
    .AddPolicies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.RegisterMinimalApis();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();


await builder.Services.MigrateDatabase();

app.Run();