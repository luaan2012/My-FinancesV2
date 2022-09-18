using Finances.Domain.IRepository;
using Finances.Identity;
using Finances.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Finances.Domain.Repository
{   
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;

        public UserRepository(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager,
                            ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = applicationDbContext;
        }

        public async Task<bool> CreateUser(IdentityUser identityUser, Users user)
        {

            var result = await _db.MyUser.AddAsync(user);
            await _db.SaveChangesAsync();
            
            return true; 
        }

        public async Task<Users> FindUserByUserName(string userName)
        {
            return await _db.MyUser.AsNoTracking().Where(x => x.UserName == userName).FirstOrDefaultAsync() ?? new Users();
        }

        public async Task<Users> ObterById(Guid id)
        {
            return await ObterId(id);
        }

        public async Task<Users> GetAllInf(Guid id)
        {
            var user = await _db.MyUser.Where(x => x.Id == id).Include(x => x.Projects).Include(x => x.Remembers)
                                                          .Include(x => x.HistoryEvenues).Include(x => x.ToDos).Include(x => x.Revenues)
                                                          .Include(x => x.VisitorsCountries).Include(x => x.Debts).FirstOrDefaultAsync();
            return user;
        }
    }
}
