using System;
using System.Collections.Generic;

namespace Kanban.Model.Models
{
    public class ListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? IndexList { get; set; }

        public ICollection<TaskModel> Tasks { get; set; }
    }

    public class TaskModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? OwnerId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? Priority { get; set; }
        public int? AssignedEmployeeId { get; set; }
        public double? IndexTask { get; set; }
        public int ListId { get; set; }

        public EmployeeModel AssignedEmployee { get; set; }
        public EmployeeModel Owner { get; set; }
        public ICollection<ChecklistModel> Checklist { get; set; }
    }

    public class ChecklistModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TaskId { get; set; }
        public ICollection<TodoItemModel> TodoItem { get; set; }
    }

    public class TodoItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ChecklistId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ListModel<T>
    {
        public int Id { get; set; }
        public T value { get; set; }
    }
}
