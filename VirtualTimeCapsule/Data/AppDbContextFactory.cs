using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using System;
using System.IO;

namespace VirtualTimeCapsule.Api.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            // Este é o caminho mais robusto para as ferramentas de design-time
            // Ele pega o diretório de execução do assembly do projeto.
            var basePath = Path.GetDirectoryName(typeof(AppDbContextFactory).Assembly.Location);

            if (string.IsNullOrEmpty(basePath))
            {
                // Fallback se o GetDirectoryName retornar nulo ou vazio (improvável em IDEs, mas para robustez)
                basePath = Directory.GetCurrentDirectory();
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) // Usar o basePath ajustado
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 36)), // CONFIRME SUA VERSÃO DO MYSQL AQUI!
                mySqlOptions => mySqlOptions.EnableRetryOnFailure());

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}