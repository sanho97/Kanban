using Kanban.Model.Entities;
using Kanban.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanban.Model.Shared.Repository
{
    public interface IListRepository : IGenericRepository<List>
    {
        Task<IList<ListModel>> GetLists();
    }
}
