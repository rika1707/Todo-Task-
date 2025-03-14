using TaskWebApi.Models.DTOs;

namespace TaskWebApi.Repository.IRepository
{
    public interface IAccessloginRepository
    {
        public Task<bool> Login(LoginDto loginDto);
    }
}
