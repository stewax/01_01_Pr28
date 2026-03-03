using Kino_Kazakov.Classes.Common;
using Kino_Kazakov.Models;
using Microsoft.EntityFrameworkCore;

namespace Kino_Kazakov.Classes
{
    public class ClubsContext:DbContext
    {
        public DbSet<Clubs> Clubs { get; set; }

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
