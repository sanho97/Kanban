using Kanban.Model.Entities;
using Kanban.Model.Shared.Repository;
using Kanban.Repository.Collections;

namespace Kanban.Repository.Repositories
{
    public class ChecklistRepository : GenericRepository<Checklist>, IChecklistRepository
    {
        public ChecklistRepository(KanbanDBContext context) : base(context)
        {

        }

        public async System.Threading.Tasks.Task DeleteChecklist(int id)
        {
              _context.Checklist.Remove(new Checklist { Id = id });

            await _context.SaveChangesAsync();
        }
    }
}
