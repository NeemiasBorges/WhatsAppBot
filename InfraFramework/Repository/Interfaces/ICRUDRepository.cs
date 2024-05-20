
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfraFramework.Repository.Interfaces
{
    public interface ICRUDRepository<TEntity>
    {
        Task Add(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Remove(int id);
        Task<IEnumerable<TEntity>> List();
    }
}
