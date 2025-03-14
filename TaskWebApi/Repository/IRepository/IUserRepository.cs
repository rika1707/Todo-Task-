using TaskWebApi.Models;

namespace TaskWebApi.Repository.IRepository
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAll();
        public Task<User?> GetById(Guid id);
        public Task<bool> CreateUser(User user);
        public Task<bool> Update(User user);
        public Task<bool> DeleteById(Guid id);
    }
}
