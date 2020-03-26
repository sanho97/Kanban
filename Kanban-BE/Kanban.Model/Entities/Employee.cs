using System;
using System.Collections.Generic;

namespace Kanban.Model.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            TaskAssignedEmployee = new HashSet<Task>();
            TaskOwner = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Task> TaskAssignedEmployee { get; set; }
        public ICollection<Task> TaskOwner { get; set; }
    }
}
