using Finances.Domain.IRepository;
using Finances.Models;
using Finances.Services.IServices;
using Microsoft.AspNetCore.Http;

namespace Finances.Services.Services
{
    public class GeralService : IGeralService
    {
        private readonly IGeralRepository _geralRepository;

        public GeralService(IGeralRepository geralRepository)
        {
            _geralRepository = geralRepository;
        }
       
        public async Task<int> CompleteToDo(ToDo toDo)
        {
            return await _geralRepository.CompleteToDo(toDo);
        }

        public async Task<int> RemoveToDo(Guid id)
        {
            return await _geralRepository.RemoveToDo(id);
        }
        
        public async Task<int> SaveToDo(ToDo toDo)
        {
            return await _geralRepository.SaveToDo(toDo);
        }

        public async Task<int> RemoveProject(Guid id)
        {
            return await _geralRepository.RemoveProject(id);
        }
        public async Task<int> SaveProject(Projects projects)
        { 
            return await _geralRepository.SaveProject(projects);
        }

        public async Task<int> ChangeGoal(Projects projects)
        {
            return await _geralRepository.ChangeGoal(projects);
        }

        public async Task<int> AddRemember(Remember id)
        {
            return await _geralRepository.AddRemember(id);
        }

        public async Task<int> RemoveRemember(Guid id)
        {
            return await _geralRepository.RemoveRemember(id);
        }

        public async Task<int> AddDebts(Debts debts)
        {
            return await _geralRepository.AddDebts(debts);
        }

        public async Task<int> RemoveDebts(Guid id)
        {
            return await _geralRepository.RemoveDebts(id);
        }

        public async Task<int> ChangeDebts(Debts debts, bool pay)
        {
            return await _geralRepository.ChangeDebts(debts, pay);
        }

        public async Task<int> FirstLogin(Users users)
        {
            return await _geralRepository.FirstLogin(users);
        }

        public Task<int> SaveVisitor(VisitorsCountries visitor)
        {
            return _geralRepository.SaveVisitor(visitor);
        }

        public Task<int> RemoveVisitor(Guid id)
        {
            return _geralRepository.RemoveVisitor(id);
        }

        public Task<int> ChangeGoalTravel(VisitorsCountries visitor)
        {
            return _geralRepository.ChangeGoalTravel(visitor);
        }

        public Task<int> ChangeGoalProject(Projects projects)
        {
            return _geralRepository.ChangeGoalProject(projects);
        }

        public async Task<IEnumerable<Debts>> GetDebts(Guid id)
        {
            return await _geralRepository.GetDebts(id);
        }
    }
}
