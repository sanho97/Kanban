using Kanban.Model.Entities;
using Kanban.Model.Models;
using Kanban.Model.Shared.Repository;
using Kanban.Repository.Collections;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Repository.Repositories
{
    public class ListRepository : GenericRepository<List>, IListRepository
    {
        public ListRepository(KanbanDBContext context) : base(context) { }


        public async Task<IList<ListModel>> GetLists()
        {
            return await _context.List.OrderBy(q => q.IndexList).Select(x => new ListModel
            {
                Id = x.Id,
                Name = x.Name,
                IndexList = x.IndexList,
                Tasks = x.Task.OrderBy(_ => _.IndexTask).Select(c => new TaskModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    OwnerId = c.OwnerId,
                    StartDate = c.StartDate,
                    DueDate = c.DueDate,
                    Priority = c.Priority,
                    AssignedEmployeeId = c.AssignedEmployeeId,
                    IndexTask = c.IndexTask,
                    ListId = c.ListId,
                    AssignedEmployee = new EmployeeModel
                    {
                        Id = c.AssignedEmployee.Id,
                        Name = c.AssignedEmployee.Name
                    },
                    Owner = new EmployeeModel
                    {
                        Id = c.Owner.Id,
                        Name = c.Owner.Name
                    },
                    Checklist = c.Checklist.Select(d => new ChecklistModel
                    {
                        Id = d.Id,
                        Name = d.Name,
                        TaskId = d.TaskId,
                        TodoItem = d.TodoItem.Select(e => new TodoItemModel
                        {
                            Id = e.Id,
                            Name = e.Name,
                            IsActive = e.IsActive,
                            ChecklistId = e.ChecklistId
                        }).ToList()
                    }).ToList()
                }).ToList()
            }).ToListAsync();
        }
    }
}
