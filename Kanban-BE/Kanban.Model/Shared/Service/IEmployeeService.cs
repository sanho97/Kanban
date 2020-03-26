using Kanban.Model.Entities;
using Kanban.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Model.Shared.Service
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> Get(int id);
        Task<IEnumerable<Employee>> GetAll();
    }
}
