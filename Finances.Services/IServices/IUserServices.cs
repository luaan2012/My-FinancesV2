using Finances.Models;
using Microsoft.AspNetCore.Identity;


namespace Finances.Services.IServices
{
    public interface IUserServices
    {
        Task<bool> CreateUser(IdentityUser identityUser, Users user);
        Task<Users> FindUserByUserName(string userName);
        Task<Users> ObterById(Guid id);
        Task<Users> GetAllInf(Guid id);
    }
}
