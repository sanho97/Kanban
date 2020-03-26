using Kanban.Model.Entities;
using Kanban.Model.Models;
using Kanban.Model.Shared.Repository;
using Kanban.Repository.Collections;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Kanban.Repository.Repositories
{
    public class TaskRepository : GenericRepository<Model.Entities.Task>, ITaskRepository
    {
        public TaskRepository(KanbanDBContext context) : base(context)
        {

        }

        public async Task<TaskModel> GetTaskAsyn(int id) => await _context.Task.Where(_ => _.Id == id).Select(c => new TaskModel
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
        }).FirstAsync();
        
        public async System.Threading.Tasks.Task DeleteTask(int id)
        {
            _context.Task.Remove(new Model.Entities.Task { Id = id });

            await _context.SaveChangesAsync();
        }
    }
}
