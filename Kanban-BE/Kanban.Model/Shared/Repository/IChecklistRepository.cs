using Kanban.Model.Entities;

namespace Kanban.Model.Shared.Repository
{
    public interface IChecklistRepository : IGenericRepository<Checklist>
    {
        System.Threading.Tasks.Task DeleteChecklist(int id);
    }
}
