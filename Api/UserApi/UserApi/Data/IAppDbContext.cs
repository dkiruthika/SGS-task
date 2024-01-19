using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi.Data
{
    public interface IAppDbContext
    {
        DbSet<User> Users { get; set; }

        public int SaveChanges();
    }
}