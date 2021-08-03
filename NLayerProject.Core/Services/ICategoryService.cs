using NLayerProject.Core.Model;
using System.Threading.Tasks;

namespace NLayerProject.Core.Services
{
    public interface ICategoryService:IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        //Category özgü metodlar varsa burada tanimlanabilir.
    }
}
