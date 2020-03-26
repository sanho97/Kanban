using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Kanban.Model.Entities;
using Kanban.Model.Shared.Service;
using System.Threading.Tasks;
using Kanban.Model.Models;

namespace Kanban.Api.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployee() => await _employeeService.GetAll();

        [HttpGet("{id:int}")]
        public async Task<EmployeeModel> Get(int id) => await _employeeService.Get(id);
    }
}