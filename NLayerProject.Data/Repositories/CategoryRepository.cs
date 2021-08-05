using Microsoft.EntityFrameworkCore;
using NLayerProject.Core.Model;
using NLayerProject.Core.Repositories;
using System.Threading.Tasks;

namespace NLayerProject.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products)
                .SingleOrDefaultAsync(x => x.Id == categoryId);
        }
    }
}
