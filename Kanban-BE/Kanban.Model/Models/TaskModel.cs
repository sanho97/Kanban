using System;
using System.Collections.Generic;
using System.Text;

namespace Kanban.Model.Models
{
    public class TaskModelToEdit<T>
    {
        public int Id { get; set; }
        public T Value {get; set; }

    }
}
