using Kanban.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Model.Shared.Repository
{
    public interface ITodoItemRepository : IGenericRepository<TodoItem>
    {
        System.Threading.Tasks.Task DeleteTodoItem(int id);
    }
}
