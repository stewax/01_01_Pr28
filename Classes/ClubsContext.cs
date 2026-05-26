using Kino_Osennikov.Classes.Common;
using Kino_Osennikov.Models;
using Microsoft.EntityFrameworkCore;

namespace Kino_Osennikov.Classes
{
    public class ClubsContext : DbContext
    {
        // Все таблицы проекта должны быть здесь
        public DbSet<Clubs> Clubs { get; set; }
        public DbSet<Users> Users { get; set; }

        public ClubsContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
        }
    }
}