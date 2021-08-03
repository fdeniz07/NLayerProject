using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLayerProject.Core.Model;

namespace NLayerProject.Core.Services
{
    internal interface IProductService:IService<Product>
    {
        //Repositories altindaki IProductRepository veritabani ile ilgili islemleri yaparken burasi hem veritabani ile ilgili islemler hem de kendi icindeki 
        //veritabanina bagli olmayan islemleri yapabilir.
        //bool ControlInnerBarcode(Product product); --> Örnek ic islem. Herhangi bir veritabani baglantisi yok

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
