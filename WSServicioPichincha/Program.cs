using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WSServicioPichincha.Business.Interfaces;
using WSServicioPichincha.Business.Services;
using WSServicioPichincha.Data.Context;
using WSServicioPichincha.Data.Interfaces;
using WSServicioPichincha.Data.Repositories;
using WSServicioPichincha.Domain.Entities;
using WSServicioPichincha.Domain.Middlewares;
using WSServicioPichincha.Security.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(option =>
    option.AddPolicy(name: "pichincha",
    builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    })
);

builder.Configuration.AddJsonFile("appsettings.json");
string keyJwt = builder.Configuration.GetSection("JwtSettings").GetSection("Key").Value.ToString();
byte[] keyJwtBytes = Encoding.UTF8.GetBytes(keyJwt);
builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyJwtBytes),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PichinchaContext>(options =>
{
    options.UseSqlServer(
    builder.Configuration.GetConnectionString("PichinchaConnection"));
});

builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();

builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<ICuentaService, CuentaService>();
builder.Services.AddScoped<IMovimientosService, MovimientosService>();
builder.Services.AddScoped<IReportesService, ReportesService>();


builder.Services.AddScoped<IRepository<Persona>, Repository<Persona>>();
builder.Services.AddScoped<IRepository<Cliente>, Repository<Cliente>>();
builder.Services.AddScoped<IRepository<Movimientos>, Repository<Movimientos>>();
builder.Services.AddScoped<IRepository<Cuenta>, Repository<Cuenta>>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionMiddleware();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
