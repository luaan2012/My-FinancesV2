using AutoMapper;
using Finances.Models;
using Finances.ModelView;
using Microsoft.AspNetCore.Identity;

namespace Finances.Extensions.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Users, UserView>().ReverseMap();
            CreateMap<Users, IdentityUser>().ReverseMap();

        }
    }
}