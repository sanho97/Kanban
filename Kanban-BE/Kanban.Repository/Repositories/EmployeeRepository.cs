using Kanban.Model.Entities;
using Kanban.Model.Shared.Repository;
using Kanban.Repository.Collections;

namespace Kanban.Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(KanbanDBContext context) : base(context)
        {

        }
    }
}
