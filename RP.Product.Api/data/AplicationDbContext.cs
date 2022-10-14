

using Microsoft.EntityFrameworkCore;
using RP.Product.Api.Models;

namespace RP.Product.Api.data
{
    public class AplicationDbContext:DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Producto> Productos { get; set; }
    }
}
