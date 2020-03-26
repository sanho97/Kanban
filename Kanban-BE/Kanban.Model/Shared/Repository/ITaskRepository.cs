using Kanban.Model.Entities;
using Kanban.Model.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Model.Shared.Repository
{
    public interface ITaskRepository : IGenericRepository<Model.Entities.Task>
    {
        Task<TaskModel> GetTaskAsyn(int id);
        System.Threading.Tasks.Task DeleteTask(int id);
    }
}
