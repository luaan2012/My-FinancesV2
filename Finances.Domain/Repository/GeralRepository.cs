using Finances.Domain.IRepository;
using Finances.Enums;
using Finances.Identity;
using Finances.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.Repository
{
    public class GeralRepository : BaseRepository<ToDo>, IGeralRepository
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;

        public GeralRepository(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = applicationDbContext;
        }        

        public async Task<int> SaveToDo(ToDo toDo)
        {
            await _db.ToDos.AddAsync(toDo);
            return await SaveChanges();
        }

        public async Task<int> RemoveToDo(Guid id)
        {
            var toDo = await _db.ToDos.FindAsync(id);

            if(toDo is null) return 0;

            _db.ToDos.Remove(toDo);

            return await SaveChanges();
        }

        public async Task<int> CompleteToDo(ToDo toDo)
        {
            var result = await _db.ToDos.FindAsync(toDo.Id);

            if (toDo is null) return 0;

            result.Complete = toDo.Complete;

            _db.ToDos.Update(result);

            return await SaveChanges();
        }

        public async Task<int> SaveProject(Projects projects)
        {
            await _db.Projects.AddAsync(projects);
            return await SaveChanges();
        }

        public async Task<int> RemoveProject(Guid id)
        {
            var result = await _db.Projects.FindAsync(id);

            if (result is null) return 0;

            _db.Projects.Remove(result);

            return await SaveChanges();
        }

        public async Task<int> ChangeGoal(Projects projects)
        {
            var result = await _db.Projects.FindAsync(projects.Id);

            if (result is null) return 0;

            result.Goal = projects.Goal;
            result.Name = projects.Name;
            result.ImageName = projects.ImageName;
            result.Description = projects.Description;

            _db.Projects.Update(result);

            return await SaveChanges();
        }

        public async Task<int> AddRemember(Remember remember)
        {
            await _db.Remembers.AddAsync(remember);

            return await SaveChanges();
        }

        public async Task<int> RemoveRemember(Guid id)
        {
            var result = await _db.Remembers.FindAsync(id);

            if (result is null) return 0;

            _db.Remembers.Remove(result);

            return await SaveChanges();
        }

        public async Task<int> AddDebts(Debts debts)
        {
            await _db.AddAsync(debts);
            return await SaveChanges();
        }

        public async Task<int> RemoveDebts(Guid id)
        {
            var result = await _db.Debts.FindAsync(id);

            if (result is null) return 0;

            _db.Debts.Remove(result);

            return await SaveChanges();
        }

        public async Task<int> ChangeDebts(Debts debts, bool pay)
        {
            var result = await _db.Debts.FindAsync(debts.Id);

            if (result is null) return 0;

            if (pay)
                result.Status = TypeStatusPay.Pago;
            else
                result.Status = TypeStatusPay.Pendente;

            _db.Debts.Update(result);

            return await SaveChanges();
        }

        public async Task<int> FirstLogin(Users users)
        {
            var result = await _db.MyUser.FindAsync(users.Id);

            if (result is null) return 0;

            result.FirtsLogin = false;
            result.ReceiveSalary = users.ReceiveSalary;
            result.Salary = users.Salary;

            _db.MyUser.Update(result);

            return await SaveChanges();
        }

        public async Task<int> SaveVisitor(VisitorsCountries visitor)
        {
            _db.VisitorsCountries.Add(visitor);

            return await SaveChanges();
        }

        public async Task<int> RemoveVisitor(Guid id)
        {
            var result = await _db.VisitorsCountries.FindAsync(id);

            if (result is null) return 0;

            _db.VisitorsCountries.Remove(result);

            return await SaveChanges();
        }

        public async Task<int> ChangeGoalTravel(VisitorsCountries visitor)
        {
            var result = await _db.VisitorsCountries.FindAsync(visitor.Id);

            if (result is null) return 0;

            result.ValueGoal = visitor.ValueGoal;

            _db.VisitorsCountries.Update(result);

            return await SaveChanges();
        }

        public async Task<int> ChangeGoalProject(Projects projects)
        {
            var result = await _db.Projects.FindAsync(projects.Id);

            if (result is null) return 0;

            result.Goal = projects.Goal;

            _db.Projects.Update(result);

            return await SaveChanges();
        }

        public async Task<IEnumerable<Debts>> GetDebts(Guid id)
        {
            var result = await _db.Debts.Where(x => x.UsersId == id).ToListAsync();

            if (result is null) return null;

            return result;
        }
    }
}
