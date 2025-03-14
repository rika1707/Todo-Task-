using Microsoft.EntityFrameworkCore;
using TaskWebApi.Context;
using TaskWebApi.Models.DTOs;
using TaskWebApi.Repository.IRepository;

namespace TaskWebApi.Repository
{
    public class LoginRepository : IAccessloginRepository
    {
        private readonly TaskDbContext _taskDbContext;
        public LoginRepository(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
        public async Task<bool> Login(LoginDto loginDto)
        {
            var user = await _taskDbContext.Users.FirstOrDefaultAsync(u =>
                            u.UserName == loginDto.UserName &&
                            u.Password == loginDto.Password);
            if (user == null) return false;
            return true;
        }
    }
}
