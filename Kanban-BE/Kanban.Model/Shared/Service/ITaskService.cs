using Kanban.Model.Entities;
using Kanban.Model.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Task = Kanban.Model.Entities.Task;

namespace Kanban.Model.Shared.Service
{
    public interface ITaskService
    {
        Task<TaskModel> Get(int id);

        Task<TaskModel> Add(TaskModel model);

        System.Threading.Tasks.Task Delete(int id);

        System.Threading.Tasks.Task UpdatePosition(TaskModel model);

        System.Threading.Tasks.Task UpdateName(TaskModelToEdit<string> model);

        System.Threading.Tasks.Task UpdateStartDate(TaskModelToEdit<DateTime> model);

        System.Threading.Tasks.Task UpdateDuaDate(TaskModelToEdit<DateTime> model);

        System.Threading.Tasks.Task UpdateAssignEmployee(TaskModelToEdit<int> model);

        System.Threading.Tasks.Task UpdateOwner(TaskModelToEdit<int> model);
    }
}
