using System;
using System.Collections.Generic;

namespace Kanban.Model.Entities
{
    public partial class Task
    {
        public Task()
        {
            Checklist = new HashSet<Checklist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? OwnerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? Priority { get; set; }
        public int? AssignedEmployeeId { get; set; }
        public double? IndexTask { get; set; }
        public int ListId { get; set; }

        public Employee AssignedEmployee { get; set; }
        public List List { get; set; }
        public Employee Owner { get; set; }
        public ICollection<Checklist> Checklist { get; set; }
    }
}
