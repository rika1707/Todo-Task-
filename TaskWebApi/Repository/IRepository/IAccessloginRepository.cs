using TaskWebApi.Models;
using TaskWebApi.Models.DTOs;

namespace TaskWebApi.Repository.IRepository
{
    public interface IAccessloginRepository
    {
        public Task<User?> Login(LoginDto loginDto);
    }
}
