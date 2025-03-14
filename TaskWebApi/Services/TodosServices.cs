using AutoMapper;
using TaskWebApi.Models;
using TaskWebApi.Models.DTOs;
using TaskWebApi.Repository.IRepository;

namespace TaskWebApi.Services
{
    public class TodosService
    {
        private readonly ITodosRepository _todosRepository;
        private readonly IMapper _mapper;
        public TodosService(ITodosRepository todosRepository, IMapper mapper)
        {
            _todosRepository = todosRepository;
            _mapper = mapper;
        }

        public async Task<List<Todos>> GetAllTodos(Guid IdUser)
        {
            return await _todosRepository.GetAll(IdUser);
           
        }

        public async Task<Todos?> getTodoById(Guid Id)
        {
            return await _todosRepository.GetById(Id);
            
        }

        public async Task<bool> createtodo(CreateTodoDto todoDto)
        {
            var todo = _mapper.Map<Todos>(todoDto);
            return await _todosRepository.Createtodo(todo);
        }

        public async Task<bool> updateTodo(Todos todo)
        {
            return await _todosRepository.Update(todo);
        }

        public async Task<bool> processTask(Guid Id)
        {
            return await _todosRepository.ProcessTask(Id);
        }

        public async Task<bool> deleteTodo(Guid Id)
        {
            return await _todosRepository.DeleteById(Id);
        }
    }
}
