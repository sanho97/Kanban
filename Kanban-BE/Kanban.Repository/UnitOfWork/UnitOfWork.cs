using Kanban.Model.Entities;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Repository;
using Kanban.Repository.Repositories;
using System;

namespace Kanban.UnitOfWork.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private KanbanDBContext _context;

        public UnitOfWork(KanbanDBContext context)
        {
            _context = context;
            InitReponsitory();
        }

        public IEmployeeRepository EmployeeRepository { get; private set; }

        public ITaskRepository TaskRepository { get; private set; }

        public IListRepository ListRepository { get; private set; }

        public IChecklistRepository ChecklistRepository { get; private set; }

        public ITodoItemRepository TodoItemRepository { get; private set; }

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            // Execute if resources have not already been disposed
            if (!_disposed)
            {
                // If the call is from Dispose, free managed resources
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// To release unmanaged resources before an object is garbage-collected.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            // Requests that the common language runtime not call the finalizer for the specified object.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Init Objects Repository 
        /// </summary>
        private void InitReponsitory() {
            EmployeeRepository = new EmployeeRepository(_context);
            TaskRepository = new TaskRepository(_context);
            ListRepository = new ListRepository(_context);
            ChecklistRepository = new ChecklistRepository(_context);
            TodoItemRepository = new TodoItemRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
