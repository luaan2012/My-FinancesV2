using Finances.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finances.Domain.IRepository
{
    public interface IUserRepository : IDisposable
    {
        Task<bool> CreateUser(IdentityUser identityUser, Users user);
        Task<Users> FindUserByUserName(string userName);
        Task<Users> ObterById(Guid id);
        Task<Users> GetAllInf(Guid id);
    }
}
