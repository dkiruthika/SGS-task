using UserApi.Models;
using Microsoft.EntityFrameworkCore;
namespace UserApi.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public override int SaveChanges()
        {
            int result=base.SaveChanges();
            return result;
        }
    }
}
