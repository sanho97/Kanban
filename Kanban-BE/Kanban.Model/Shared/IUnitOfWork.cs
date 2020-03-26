using Kanban.Model.Shared.Repository;
using System;

namespace Kanban.Model.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository EmployeeRepository { get; }

        ITaskRepository TaskRepository { get; }

        IListRepository ListRepository { get; }

        IChecklistRepository ChecklistRepository { get; }

        ITodoItemRepository TodoItemRepository { get; }

        void Save();
    }
}
