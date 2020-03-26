using AutoMapper;
using Kanban.Model.Entities;
using Kanban.Model.Models;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Service.Implements
{
    public class TodoItemService : BaseService, ITodoItemService
    {
        private readonly IMapper _mapper;

        public TodoItemService(IUnitOfWork unitOfWork, IMapper mapper) : base (unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<int> Add(TodoItemModel model)
        {
            var todoItem = _mapper.Map<TodoItem>(model);

            await _unitOfWork.TodoItemRepository.AddAsyn(todoItem);

            return model.Id;
        }

        public async Task<TodoItem> Get(int id) => await _unitOfWork.TodoItemRepository.GetAsyn(id);

        public async System.Threading.Tasks.Task UpdateName(TodoItemModel<string> model)
        {
            var todoItem = await Get(model.Id);

            todoItem.Name= model.Value;

            _unitOfWork.Save();
        }

        public async System.Threading.Tasks.Task UpdateStatus(TodoItemModel<bool> model)
        {
            var todoItem = await Get(model.Id);

            todoItem.IsActive = model.Value;

            _unitOfWork.Save();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            await _unitOfWork.TodoItemRepository.DeleteTodoItem(id);
        }
    }
}
