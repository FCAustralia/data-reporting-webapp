using App.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace App.Data
{
    public class AppContext:DbContext
    {
        public readonly IConfiguration _config;

        public AppContext(IConfiguration config)
        {
            _config = config;
        }
        public DbSet<Dossier> Dossiers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config["ConnectionStrings"], b => b.MigrationsAssembly("App.Form"));
            
        }
    }

}
