using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(int id);
        Task<IQueryable<TEntity>> GetAll();
        Task Insert(TEntity entity);
        Task Update(int id, TEntity entity);
        Task Delete(int id);

    }
}