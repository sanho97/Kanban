using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Model.Models
{
    public class TodoItemModel<T>
    {
        public int Id { get; set; }
        public T Value { get; set; }
        public int? ChecklistId { get; set; }
    }
}
