using TaskWebApi.Models;
using TaskWebApi.Models.DTOs;

namespace TaskWebApi.Repository.IRepository
{
    public interface ITodosRepository
    {
        public Task<List<Todos>> GetAll(Guid IdUser);
        public Task<Todos?> GetById(Guid id);
        public Task<bool> Createtodo(Todos todo);
        public Task<bool> Update(Todos todo);
        public Task<bool> ProcessTask(Guid id);
        public Task<bool> DeleteById(Guid id);
    }
}
