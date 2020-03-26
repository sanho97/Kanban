using AutoMapper;
using Kanban.Model.Entities;
using Kanban.Model.Models;

namespace Kanban.Model
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Task, TaskModel>().ReverseMap();

            CreateMap<Checklist, ChecklistModel>().ReverseMap();

            CreateMap<TodoItem, TodoItemModel>().ReverseMap();

            CreateMap<Employee, EmployeeModel>().ReverseMap();
        }
    }
}
