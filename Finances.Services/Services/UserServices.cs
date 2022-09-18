using Finances.Domain.IRepository;
using Finances.Models;
using Finances.Services.IServices;
using Microsoft.AspNetCore.Identity;

namespace Finances.Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserServices(IUserRepository userRepository, SignInManager<IdentityUser> signInManager)
        {
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        public async Task<bool> CreateUser(IdentityUser identityUser, Users user)
        {
            return await _userRepository.CreateUser(identityUser, user);
        }

        public async Task<Users> FindUserByUserName(string userName)
        {
            return await _userRepository.FindUserByUserName(userName);
        }

        public Task<Users> ObterById(Guid id)
        {
            return _userRepository.ObterById(id);
        }

        public Task<Users> GetAllInf(Guid id)
        {
            return _userRepository.GetAllInf(id);
        }
    }
}
