using AutoMapper;
using Kanban.Model.Entities;
using Kanban.Model.Models;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanban.Service.Implements
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork){
            _mapper = mapper;
        }

        public async Task<EmployeeModel> Get(int id) => _mapper.Map<EmployeeModel>(await _unitOfWork.EmployeeRepository.GetAsyn(id));

        public async Task<IEnumerable<Employee>> GetAll() => await _unitOfWork.EmployeeRepository.GetAllAsyn();
    }
}
