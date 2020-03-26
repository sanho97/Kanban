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
    [Route("api/checklists")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        IChecklistService _checklistService;

        public ChecklistController(IChecklistService checklistService)
        {
            _checklistService = checklistService;
        }

        // POST: api/Checklists
        [HttpPost]
        public async Task<ChecklistModel> Post([FromBody] ChecklistModel model) => await _checklistService.Add(model);

        // PUT: api/Checklists/5
        [HttpPut("{id}")]
        public async System.Threading.Tasks.Task Put([FromBody] ChecklistModel model) => await _checklistService.Update(model, model.Id);

        // DELETE: api/Checklists/5
        [HttpDelete("{id}")]
        public async System.Threading.Tasks.Task Delete(int id) => await _checklistService.Delete(id);
    }
}
