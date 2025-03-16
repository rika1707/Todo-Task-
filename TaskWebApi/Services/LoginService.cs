using TaskWebApi.Models.DTOs;
using TaskWebApi.Repository.IRepository;

namespace TaskWebApi.Services
{
    public class LoginService
    {
        private readonly IAccessloginRepository _accessloginRepository;
        private readonly AuthService _authService;

        public LoginService(IAccessloginRepository accessloginRepository,
                            AuthService authService)
        {
            _accessloginRepository = accessloginRepository;
            _authService = authService;
        }

        public async Task<LoginResponseDto> Login(LoginDto loginDto)
        {
            var IsLogged = await _accessloginRepository.Login(loginDto);
            if (IsLogged is null)
            {
                return new LoginResponseDto
                { Exito = false, Message = "Usuario o Contraseña Incorrectos" };
            }
            var token = _authService.GenerateJwtToken(loginDto.UserName);
            return new LoginResponseDto { Exito = true, Message = "Usuario Logeado con Exito",
                                          Id= IsLogged.Id,
                                          UserName = loginDto.UserName,
                                          Token = token
                                        };
        }
    }
}
