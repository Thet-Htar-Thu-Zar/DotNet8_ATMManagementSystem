using AutoMapper;
using Model.DTOs;
using Model.Entities;

namespace ATMManagementSystem
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Users, CreateUserDTOs>().ReverseMap();

        }

    }
}
