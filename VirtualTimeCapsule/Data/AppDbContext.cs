using Microsoft.EntityFrameworkCore;
using VirtualTimeCapsule.Api.Models;

namespace VirtualTimeCapsule.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<CapsulaTempo> CapsulaTempo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}