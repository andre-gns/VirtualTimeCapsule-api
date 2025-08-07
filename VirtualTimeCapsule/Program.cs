using VirtualTimeCapsule.Api.Data;
using Microsoft.EntityFrameworkCore;
using VirtualTimeCapsule.Api.Services;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
// OtherInformation: <PackageReference Include="Microsoft.EntityFrameworkCore" Version="8.0.36" />

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// 
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString,
        new MySqlServerVersion(new Version(8, 0, 36)), // Substitua pela sua versão do MySQL Server (ex: 8.0.36)
        mysqlOptions => mysqlOptions.EnableRetryOnFailure())
);
builder.Services.AddHostedService<MySchedulerService>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Map controllers to routes

app.Run();