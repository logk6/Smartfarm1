using Microsoft.EntityFrameworkCore;
using Smartfarm1.Models;

namespace Smartfarm1.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<FarmStatus> FarmStatus { set; get; }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
