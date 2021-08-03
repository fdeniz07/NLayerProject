using NLayerProject.Core.Model;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IProductService:IService<Product>
    {
        //Repositories altindaki IProductRepository veritabani ile ilgili islemleri yaparken burasi hem veritabani ile ilgili islemler hem de kendi icindeki 
        //veritabanina bagli olmayan islemleri yapabilir.
        //bool ControlInnerBarcode(Product product); --> Örnek ic islem. Herhangi bir veritabani baglantisi yok

        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
