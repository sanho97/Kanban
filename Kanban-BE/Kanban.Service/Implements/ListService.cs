using Kanban.Model.Models;
using Kanban.Model.Shared;
using Kanban.Model.Shared.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kanban.Service.Implements
{
    public class ListService : BaseService, IListService
    {
        public ListService(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public async Task<IList<ListModel>> GetLists() => await _unitOfWork.ListRepository.GetLists();

        public async Task UpdatePosition(ListModel<double> model)
        {
            var list = await _unitOfWork.ListRepository.GetAsyn(model.Id);

            list.IndexList = model.value;

            _unitOfWork.Save();
        }
    }
}
