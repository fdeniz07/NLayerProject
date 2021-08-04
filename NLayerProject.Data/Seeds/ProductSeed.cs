using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerProject.Core.Model;

namespace NLayerProject.Data.Seeds
{
    //Seed Bölümü : Bizim default olarak DB ye veriler girmemizi saglar

    class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;

        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Pilot Kalem",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _ids[0]
                }, //DB olusturulmadan önce data olusturulacaksa mutlaka Id girilmelidir. Sonradan girilecek Id degeri girmeye gerek yoktur.

                new Product
                {
                    Id = 2,
                    Name = "Kursun Kalem",
                    Price = 10.50m,
                    Stock = 200,
                    CategoryId = _ids[0]
                },

                new Product
                {
                    Id = 3,
                    Name = "Tükenmez Kalem",
                    Price = 20.50m,
                    Stock = 300,
                    CategoryId = _ids[0]
                },

                new Product
                {
                    Id = 4,
                    Name = "Kücük Boy Defter",
                    Price = 10.50m,
                    Stock = 100,
                    CategoryId = _ids[1]
                },

                new Product
                {
                    Id = 5,
                    Name = "Orta Boy Defter",
                    Price = 12.50m,
                    Stock = 100,
                    CategoryId = _ids[1]
                },

                new Product
                {
                    Id = 6,
                    Name = "Büyük Boy Defter",
                    Price = 15.50m,
                    Stock = 100,
                    CategoryId = _ids[1]
                }
            );
        }
    }
}
