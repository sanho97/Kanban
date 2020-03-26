using Kanban.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Model.Shared.Service
{
    public interface IListService
    {
        Task<IList<ListModel>> GetLists();

        System.Threading.Tasks.Task UpdatePosition(ListModel<double> model);
    }
}
