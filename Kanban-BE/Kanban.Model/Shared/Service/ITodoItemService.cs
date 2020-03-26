using Kanban.Model.Entities;
using Kanban.Model.Models;
using System.Threading.Tasks;

namespace Kanban.Model.Shared.Service
{
    public interface ITodoItemService
    {
        Task<TodoItem> Get(int id);

        Task<int> Add(TodoItemModel todoTiem);

        System.Threading.Tasks.Task UpdateStatus(TodoItemModel<bool> model);

        System.Threading.Tasks.Task UpdateName(TodoItemModel<string> model);

        System.Threading.Tasks.Task Delete(int id);
    }
}
