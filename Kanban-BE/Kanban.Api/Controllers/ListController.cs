using System.Collections.Generic;
using System.Threading.Tasks;
using Kanban.Model.Models;
using Kanban.Model.Shared.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kanban.Api.Controllers
{
    [Route("api/lists")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private IListService _taskListService;
        public ListController(IListService taskListService)
        {
            _taskListService = taskListService;
        }

        // GET: api/lists
        [HttpGet]
        public async Task<IList<ListModel>> Get() => await _taskListService.GetLists();
       
        [HttpPut("position")]
        public async System.Threading.Tasks.Task PutPosition(ListModel<double> model) => await _taskListService.UpdatePosition(model);
    }
}
