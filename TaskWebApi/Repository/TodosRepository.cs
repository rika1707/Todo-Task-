using Microsoft.EntityFrameworkCore;
using TaskWebApi.Context;
using TaskWebApi.Models;
using TaskWebApi.Repository.IRepository;

namespace TaskWebApi.Repository
{
    
    public class TodosRepository : ITodosRepository
    {
        private readonly TaskDbContext _taskDbContext;
        public TodosRepository(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
       

        public async Task<List<Todos>> GetAll(Guid IdUser)
        {
            var lisTodos = await _taskDbContext.Todos.Where(u=>u.IsDelete==false && u.UserId == IdUser).ToListAsync();
            if (lisTodos == null) return new List<Todos>();
            return lisTodos;
        }

        public async Task<Todos?> GetById(Guid id)
        {
            return await _taskDbContext.Todos.FindAsync(id);
        }

        public async Task<bool> Createtodo(Todos todo)
        {
            if(todo == null) return false;
            await _taskDbContext.Todos.AddAsync(todo);
            await _taskDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Update(Todos todo)
        {
            if (todo == null || todo.Id == Guid.Empty) return false;

            //Buscamos el usuario a editar o actualizar
            var todoExist = await _taskDbContext.Todos.FirstOrDefaultAsync(x => x.Id == todo.Id);
            if (todoExist == null) return false;
            _taskDbContext.Entry(todoExist).CurrentValues.SetValues(todo);
            await _taskDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ProcessTask(Guid id)
        {
            if (id == Guid.Empty) return false;

            var todo = await _taskDbContext.Todos.FindAsync(id);
            if (todo == null) return false;

            todo.IsComplete = true;
            todo.Estado = "Completado";
            _taskDbContext.Todos.Update(todo);
            await _taskDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteById(Guid id)
        {
            if (id == Guid.Empty) return false;

            var todo = await _taskDbContext.Todos.FindAsync(id);
            if (todo == null) return false;

            todo.IsDelete = true;
            _taskDbContext.Todos.Update(todo);
            await _taskDbContext.SaveChangesAsync();
            return true;
        }
    }
}
