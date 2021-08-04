using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Model;

namespace NLayerProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Burasi elimizdeki entity ler DB de tablolara dönüsürken nasil dönüsecegini belirliyoruz. Yani product ve category tablolari icerisindeki property'ler
            //Db de tablolara yazilirken uzunlugu,türü,primarykey olup olmayacagi buradan belirlenir.
        }
    }
}
