using System;
using System.Collections.Generic;

namespace Kanban.Model.Entities
{
    public partial class List
    {
        public List()
        {
            Task = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double? IndexList { get; set; }

        public ICollection<Task> Task { get; set; }
    }
}
