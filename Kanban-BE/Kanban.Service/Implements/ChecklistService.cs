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
    public class ChecklistService : BaseService, IChecklistService
    {
        private readonly IMapper _mapper;
        public ChecklistService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task<ChecklistModel> Add(ChecklistModel model)
        {
            var checklist = _mapper.Map<Checklist>(model);

            return _mapper.Map<ChecklistModel>(await _unitOfWork.ChecklistRepository.AddAsyn(checklist));
        }

        public async Task<Checklist> Update(ChecklistModel model, int id)
        {
            var checklist = _mapper.Map<Checklist>(model);

            return await _unitOfWork.ChecklistRepository.UpdateAsyn(checklist, id);
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            await _unitOfWork.ChecklistRepository.DeleteChecklist(id);
        }
    }
}
