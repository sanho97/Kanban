using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Kanban.Model.Entities;
using Kanban.Model.Models;
using Kanban.Model.Shared.Service;
using Microsoft.AspNetCore.Mvc;
using Task = Kanban.Model.Entities.Task;

namespace Kanban.Api.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<TaskModel> Get(int id) => await _taskService.Get(id);

        // POST: api/tasks
        [HttpPost]
        public async Task<TaskModel> Post([FromBody] TaskModel model) => await _taskService.Add(model);
        
        // PUT: api/tasks/5
        [HttpPut("{id:int}")]
        public async System.Threading.Tasks.Task Put([FromBody] TaskModel model) => await _taskService.UpdatePosition(model);

        // PUT: 
        [HttpPut("name")]
        public async System.Threading.Tasks.Task PutName([FromBody] TaskModelToEdit<string> model)
        {
            await _taskService.UpdateName(model);
        }

        // PUT: 
        [HttpPut("startdate")]
        public async System.Threading.Tasks.Task PutStartDate([FromBody] TaskModelToEdit<DateTime> model)
        {
            await _taskService.UpdateStartDate(model);
        }

        // PUT: 
        [HttpPut("duadate")]
        public async System.Threading.Tasks.Task PutDuaDate([FromBody] TaskModelToEdit<DateTime> model)
        {
            await _taskService.UpdateDuaDate(model);
        }

        // PUT: 
        [HttpPut("assignemployee")]
        public async System.Threading.Tasks.Task PutAssignEmployee([FromBody] TaskModelToEdit<int> model)
        {
            await _taskService.UpdateAssignEmployee(model);
        }

        // PUT: 
        [HttpPut("owner")]
        public async System.Threading.Tasks.Task PutOwner([FromBody] TaskModelToEdit<int> model)
        {
            await _taskService.UpdateOwner(model);
        }
        
        // DELETE: api/tasks/{id}
        [HttpDelete("{id:int}")]
        public async System.Threading.Tasks.Task Delete(int id) => await  _taskService.Delete(id);
    }
}
