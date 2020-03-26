using AutoMapper;
using Kanban.Model.Entities;
using Kanban.Model.Models;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Service;
using System;
using System.Linq;
using System.Threading.Tasks;
using Task = Kanban.Model.Entities.Task;

namespace Kanban.Service.Implements
{
    public class TaskService : BaseService, ITaskService
    {
        private readonly IMapper _mapper;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork) {
            _mapper = mapper;
        }

        public async Task<TaskModel> Get(int id) => await _unitOfWork.TaskRepository.GetTaskAsyn(id);

        public async Task<TaskModel> Add(TaskModel model)
        {
            //
            // Validate

            try
            {
                model.StartDate = DateTime.Now;
                var task = _mapper.Map<Task>(model);

                await _unitOfWork.TaskRepository.AddAsyn(task);

                return await _unitOfWork.TaskRepository.GetTaskAsyn(task.Id);
            }
            catch (Exception ex)
            {
                throw;
            }           
        }
        
        public async System.Threading.Tasks.Task UpdatePosition(TaskModel model)  
        {
            //1. Get task by id input.Id
            var task = await _unitOfWork.TaskRepository.GetAsyn(model.Id);

            //2. Update task with info from input
            task.IndexTask = model.IndexTask;
            task.ListId = model.ListId;

            _unitOfWork.Save();
        }

        public async System.Threading.Tasks.Task UpdateName(TaskModelToEdit<string> model)
        {
            var task = await _unitOfWork.TaskRepository.GetAsyn(model.Id);
            task.Name = model.Value;

            _unitOfWork.Save();
        }

        public async System.Threading.Tasks.Task UpdateStartDate(TaskModelToEdit<DateTime> model)
        {
            var task = await _unitOfWork.TaskRepository.GetAsyn(model.Id);
            task.StartDate = model.Value;

            _unitOfWork.Save();
        }

        public async System.Threading.Tasks.Task UpdateDuaDate(TaskModelToEdit<DateTime> model)
        {
            var task = await _unitOfWork.TaskRepository.GetAsyn(model.Id);
            task.DueDate = model.Value;

            _unitOfWork.Save();
        }

        public async System.Threading.Tasks.Task UpdateAssignEmployee(TaskModelToEdit<int> model)
        {
            var task = await _unitOfWork.TaskRepository.GetAsyn(model.Id);
            task.AssignedEmployeeId = model.Value;

            _unitOfWork.Save();
        }

        public async System.Threading.Tasks.Task UpdateOwner(TaskModelToEdit<int> model)
        {
            var task = await _unitOfWork.TaskRepository.GetAsyn(model.Id);
            task.AssignedEmployeeId = model.Value;

            _unitOfWork.Save();
        }

        public async System.Threading.Tasks.Task Delete(int id) => await _unitOfWork.TaskRepository.DeleteTask(id);
    }
}
