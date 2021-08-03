using NLayerProject.Core.Repositories;
using System.Threading.Tasks;

namespace NLayerProject.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        //Bu pattern'in özelligi: Coklu islem yapildiginda ve islem adimlarinin birinde hata oldugunda DB tarafindaki Rollback islemlerinin yapilmasina gerek duymamamizi
        //saglayan, yapilan degisiklikleri gecici hafizada tutan ve commit isleminden sonra hata olmazsa, verilen db ye kaydedilmesini saglar.

        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }

        Task CommitAsync();

        void Commit();
    }
}
