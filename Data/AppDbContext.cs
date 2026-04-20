using Microsoft.EntityFrameworkCore;
using e_commerce.Models;

namespace e_commerce.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
         public DbSet<product> products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
