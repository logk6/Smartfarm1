using Microsoft.EntityFrameworkCore;
using Smartfarm1.Models;

namespace Smartfarm1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FarmStatus> FarmStatus { set; get; }
        //public DbSet<SmartfarmClass> SmartfarmClass { set; get; } 
        //public DbSet<User> Users { set; get; }

        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FarmStatus>().HasNoKey();
        }
        */

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
