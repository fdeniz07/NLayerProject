using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Model;
using NLayerProject.Data.Configurations;
using NLayerProject.Data.Seeds;

namespace NLayerProject.Data
{
    // Best Practice
    //DbContext sinifi temiz tutulur, kod kalabaligi yapan kodlar baska siniflara yazilarak buradan cagrilir.

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Burasi elimizdeki entity ler DB de tablolara dönüsürken nasil dönüsecegini belirliyoruz. Yani product ve category tablolari icerisindeki property'ler
            //Db de tablolara yazilirken uzunlugu,türü,primarykey olup olmayacagi buradan belirlenir.

            // modelBuilder.Entity<Product>().Property(x => x.Id).UseIdentityColumn(); --> burada yazilmasi kod kalabaligi yapacagi icin ayri bir class da olusturup,cagiriyoruz.

            modelBuilder.ApplyConfiguration(new ProductConfiguration()); //Best Practice --> Önce tablolar olusturulur
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 })); // --> Sonra varsa örnek veriler eklenir
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));
        }
    }
}
