using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface IService<TEntity> where TEntity:class
    {
        /*Buradaki kodlar IRepository ile ayni olacak.
         Peki neden ayni kodlari yazdik?

        Repositories klasöründeki IRepository interface suan icin MSSQL server ile haberlesiyor. Ileride Oracle ile haberlesecek olursa yeni bir repository olusturulur.
        Ancak service kismi(bu interface) her iki durumda da ayni kalacaktir.
                  
         */

        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        // category.SingleOrDefaultAsync(x=>x.name = "kalem")
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity); //Tekil ekleme

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);  //Coklu Ekleme

        //Silme islemi EntityFramework de senkron olarak yapilir.
        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);
    }
}
