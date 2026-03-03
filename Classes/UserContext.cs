using Kino_Kazakov.Classes.Common;
using Kino_Kazakov.Models

using Microsoft.EntityFrameworkCore;

namespace Kino_Kazakov.Classes
{
    public class UserContext:DbContext
    {
        public DbSet<Users> Users { get; set; }

        public UserContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
        }
    }
}
