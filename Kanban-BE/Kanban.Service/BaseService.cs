using Kanban.Model.Shared;

namespace Kanban.Service
{
    public abstract class BaseService
    {
        protected IUnitOfWork _unitOfWork;
        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
