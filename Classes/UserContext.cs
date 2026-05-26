//using Kino_Osennikov.Classes.Common;
//using Kino_Osennikov.Models;

//using Microsoft.EntityFrameworkCore;

//namespace Kino_Osennikov.Classes
//{
//    public class UserContext:DbContext
//    {
//        public DbSet<Users> Users { get; set; }

//        public UserContext()
//        {
//            Database.EnsureCreated();
//        }
         
//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            optionsBuilder.UseMySql(Config.ConnectionConfig, Config.Version);
//        }
//    }
//}
