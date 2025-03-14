using AutoMapper;
using TaskWebApi.Models;
using TaskWebApi.Models.DTOs;
using TaskWebApi.Repository.IRepository;

namespace TaskWebApi.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _userRepository.GetAll();
           
        }

        public async Task<User?> getUserById(Guid Id)
        {
            return await _userRepository.GetById(Id);
            
        }

        public async Task<bool> createUser(CreateUserDTo userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return await _userRepository.CreateUser(user);
        }

        public async Task<bool> updateUser(User user)
        {
            return await _userRepository.Update(user);
        }

        public async Task<bool> deleteUser(Guid Id)
        {
            return await _userRepository.DeleteById(Id);
        }
    }
}
