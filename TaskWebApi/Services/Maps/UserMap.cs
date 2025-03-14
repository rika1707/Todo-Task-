using AutoMapper;
using TaskWebApi.Models;
using TaskWebApi.Models.DTOs;

namespace TaskWebApi.Services.Maps
{
    public class UserMap:Profile
    {
        public UserMap() 
        {
            CreateMap<CreateUserDTo, User>().ReverseMap();
            CreateMap<CreateTodoDto, Todos>().ReverseMap();
        }
    }
}
