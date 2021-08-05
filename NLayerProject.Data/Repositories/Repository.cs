using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }


        /*Senkron Programlamada metottan geri deger döndürmeyen keyword "void"
         *Asenkron Programlamada metottan geri deger döndürmeyen keyword "Task" olarak isimlendirilir.
         *
         * Uygulama performansi icin mümkün oldugunca asenkron metotlar kullanilir!
         */


        public async Task AddAsync(TEntity entity)
        {
            //async await : Bundan sonra yazacagimiz metot bitene kadar bu satirda kalmasini sagliyoruz
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        //product.where(x=>x.name="Kalem")
        public async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate) //Geri deger döndürdügü icin asenkron olmayacak
        { 
           return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified; // Burasi(EntityState.Modified;) cok sütunlü tablolarda kullanmakta cok kullanisli olur.
                                                                 // Tek dezavantaji, bir alan bile degisse tüm entity alanlarini güncellemeye calisir

            //entity.name = product.name
            //entity.price = product.price ile yukaridaki performans sorunu azaltilabilir ama cok satira sahip tablolarda ölümcül olabilir.

            return entity;
        }
    }
}
