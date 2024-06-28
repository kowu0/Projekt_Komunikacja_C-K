using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Projekt_KCK.Entities;
using Projekt_KCK.Services;

namespace Projekt_KCK
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration { get; }


       public DbSet<RegisteredUser> User { get; set; } = null!;
       public DbSet<Case> Cases { get; set; }
        public DbSet<Cooler> Coolers { get; set; }
        public DbSet<Cpu> Cpus { get; set; }
        public DbSet<Gpu> Gpus { get; set; }
        public DbSet<Disk> Discs { get; set; }
        public DbSet<Motherboard> Motherboards { get; set; }
        public DbSet<Ram> Rams { get; set; }
        public DbSet<Psu> Psus { get; set; }
        public DbSet<Configurator> Configurators { get; set; }


        //public DbSet<Illness> Illnesses { get; set; } = null!;
        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=databse.db",
                x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Konfigurator"));

            options.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
        }
    }
}
