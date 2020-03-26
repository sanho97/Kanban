using System;
using System.Collections.Generic;

namespace Kanban.Model.Entities
{
    public partial class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ChecklistId { get; set; }
        public bool? IsActive { get; set; }

        public Checklist Checklist { get; set; }
    }
}
