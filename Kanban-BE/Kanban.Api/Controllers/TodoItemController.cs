using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kanban.Model.Entities;
using Kanban.Model.Models;
using Kanban.Model.Shared.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    [Route("api/todoitems")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        ITodoItemService _todoItemService;

        public TodoItemController(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        // POST: api/TodoItem
        [HttpPost]
        public async Task<int> Post([FromBody] TodoItemModel model) => await _todoItemService.Add(model);

        // PUT: api/todoitems/name
        [HttpPut("name")]
        public async System.Threading.Tasks.Task PutName([FromBody] TodoItemModel<string> model) => await _todoItemService.UpdateName(model);
        
        // PUT: api/todoitems/status
        [HttpPut("status")]
        public async System.Threading.Tasks.Task PutStatus([FromBody] TodoItemModel<bool> model) => await _todoItemService.UpdateStatus(model);
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task Delete(int id) => await _todoItemService.Delete(id);
    }
}
