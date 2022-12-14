using Finances.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Services.IServices
{
    public interface IGeralService
    {
        Task<int> SaveToDo(ToDo toDo);
        Task<int> RemoveToDo(Guid id);
        Task<int> CompleteToDo(ToDo toD);
        Task<int> SaveProject(Projects projects);
        Task<int> RemoveProject(Guid id);
        Task<int> ChangeGoal(Projects projects);
        Task<int> AddRemember(Remember projects);
        Task<int> RemoveRemember(Guid id);
        Task<int> AddDebts(Debts debts);
        Task<int> RemoveDebts(Guid id);
        Task<int> ChangeDebts(Debts debts, bool pay);
        Task<int> FirstLogin(Users users);
        Task<int> SaveVisitor(VisitorsCountries visitor);
        Task<int> RemoveVisitor(Guid id);
        Task<int> ChangeGoalTravel(VisitorsCountries visitor);
        Task<int> ChangeGoalProject(Projects projects);

    }
}
