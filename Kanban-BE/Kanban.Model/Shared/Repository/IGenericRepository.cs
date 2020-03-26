using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Model.Shared.Repository
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> Queryable { get; }

        Task<TEntity> GetAsyn(int? id);

        Task<IEnumerable<TEntity>> GetAllAsyn();

        Task<TEntity> AddAsyn(TEntity entity);

        Task<int> DeleteAsyn(TEntity entity);

        Task<TEntity> UpdateAsyn(TEntity t, object key);

        TEntity Get(int? id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Delete(int id);

        void Update(TEntity entity);
    }
}
