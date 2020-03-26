using System;
using System.Collections.Generic;

namespace Kanban.Model.Entities
{
    public partial class Checklist
    {
        public Checklist()
        {
            TodoItem = new HashSet<TodoItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TaskId { get; set; }

        public Task Task { get; set; }
        public ICollection<TodoItem> TodoItem { get; set; }
    }
}
