using Kanban.Model.Entities;
using Kanban.Model.Shared.Repository;
using Kanban.Repository.Collections;

namespace Kanban.Repository.Repositories
{
    class TodoItemRepository : GenericRepository<TodoItem>, ITodoItemRepository
    {
        public TodoItemRepository(KanbanDBContext context) : base(context)
        {

        }

        public async System.Threading.Tasks.Task DeleteTodoItem(int id)
        {
            _context.TodoItem.Remove(new TodoItem { Id = id });

            await _context.SaveChangesAsync();
            
        }
    }
}
