using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaskWebApi.Models;
using TaskWebApi.Models.DTOs;
using TaskWebApi.Services;

namespace TaskWebApi.Controllers
{

    [ApiController]
    [SwaggerTag("Servicios relacionados a la administracion de usuarios")]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // ✅ Obtener todos los usuarios
        [HttpGet]
        [SwaggerOperation(summary: "Obtener todos los usuarios")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var users = await _userService.GetAllUser();
            return Ok(users);
        }

        // ✅ Obtener usuario por ID
        [HttpGet("{id}")]
        [SwaggerOperation(summary: "Obtener usuarios por id")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            var user = await _userService.getUserById(id);
            if (user == null)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }
            return Ok(user);
        }

        // ✅ Crear usuario
        [HttpPost]
        [SwaggerOperation(summary: "Crear usuario")]
        public async Task<ActionResult<bool>> CreateUser([FromBody] CreateUserDTo userDto)
        {
            var result = await _userService.createUser(userDto);
            if (!result)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            return Ok(new { message = "Usuario creado correctamente" });
        }

        // ✅ Actualizar usuario
        [HttpPut("{id}")]
        [SwaggerOperation(summary: "Actualizar usuario")]
        public async Task<ActionResult<bool>> UpdateUser(Guid id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest(new { message = "El ID del usuario no coincide" });
            }

            var result = await _userService.updateUser(user);
            if (!result)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            return Ok(new { message = "Usuario actualizado correctamente" });
        }

        // ✅ Borrado lógico de usuario
        [HttpDelete("{id}")]
        [SwaggerOperation(summary: "Borrado logico de usuario")]
        public async Task<ActionResult<bool>> DeleteUser(Guid id)
        {
            var result = await _userService.deleteUser(id);
            if (!result)
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            return Ok(new { message = "Usuario eliminado correctamente" });
        }
    }
}
