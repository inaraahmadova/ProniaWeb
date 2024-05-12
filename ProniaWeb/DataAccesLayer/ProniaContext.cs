using Microsoft.EntityFrameworkCore;
using ProniaWeb.Models;

namespace ProniaWeb.DataAccesLayer
{
    public class ProniaContext : DbContext
    {
        public ProniaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public IEnumerable<object> Products { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=LAPTOP-ACG39MDK\\SQLEXPRESS;Database=ProniaWeb;Trusted_Connection=True;TrustServerCertificate=True");
            base.OnConfiguring(options);
        }
    }
}
