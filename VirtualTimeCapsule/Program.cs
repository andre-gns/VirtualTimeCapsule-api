using VirtualTimeCapsule.Api.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Hangfire;
using Hangfire.MySql.Core;

var builder = WebApplication.CreateBuilder(args);

// Adicionando os serviços ao contêiner.

// Configuração do AppDbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString,
        new MySqlServerVersion(new Version(8, 0, 36)), // Substitua pela sua versão do MySQL Server
        mysqlOptions => mysqlOptions.EnableRetryOnFailure())
);

// Configuração do Hangfire
var hangfireConnectionString = builder.Configuration.GetConnectionString("HangfireConnection");
builder.Services.AddHangfire(config => config
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseStorage(new MySqlStorage(hangfireConnectionString, new MySqlStorageOptions())));

builder.Services.AddHangfireServer(); // Adiciona o servidor de processamento em background

// Configuração dos Controllers, Swagger e Endpoints
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configurando o pipeline de requisição HTTP.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard(); // Habilita o Dashboard do Hangfire

app.MapControllers();

app.Run();