using Microsoft.EntityFrameworkCore;
using TaskWebApi.Context;
using TaskWebApi.Models;
using TaskWebApi.Repository.IRepository;

namespace TaskWebApi.Repository
{
    
    public class UserRepository : IUserRepository
    {
        private readonly TaskDbContext _taskDbContext;
        public UserRepository(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
       

        public async Task<List<User>> GetAll()
        {
            var listUser = await _taskDbContext.Users.Where(u=>u.IsDelete==false).ToListAsync();
            if (listUser == null) return new List<User>();
            return listUser;
        }

        public async Task<User?> GetById(Guid id)
        {
            return await _taskDbContext.Users.FindAsync(id);
        }

        public async Task<bool> CreateUser(User user)
        {
            if(user == null) return false;
            await _taskDbContext.Users.AddAsync(user);
            await _taskDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(User user)
        {
            if (user == null || user.Id == Guid.Empty) return false;

            //Buscamos el usuario a editar o actualizar
            var userExist = await _taskDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (userExist == null) return false;
            _taskDbContext.Entry(userExist).CurrentValues.SetValues(user);
            await _taskDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteById(Guid id)
        {
            if (id == Guid.Empty) return false;

            var user = await _taskDbContext.Users.FindAsync(id);
            if (user == null) return false;

            user.IsDelete = true;
            _taskDbContext.Users.Update(user);
            await _taskDbContext.SaveChangesAsync();
            return true;
        }
    }
}
