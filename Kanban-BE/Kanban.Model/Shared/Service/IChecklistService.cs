using Kanban.Model.Entities;
using Kanban.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Model.Shared.Service
{
    public interface IChecklistService
    {
        Task<ChecklistModel> Add(ChecklistModel model);

        Task<Checklist> Update(ChecklistModel model, int id);

        System.Threading.Tasks.Task Delete(int id);
    }
}
