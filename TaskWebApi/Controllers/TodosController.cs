using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TaskWebApi.Models;
using TaskWebApi.Models.DTOs;
using TaskWebApi.Services;

namespace TaskWebApi.Controllers
{

    [ApiController]
    [SwaggerTag("Servicios relacionados a la administracion de tareas")]
    [Route("api/task")]
    public class TodosController : ControllerBase
    {
        private readonly TodosService _todosService;

        public TodosController(TodosService todosService)
        {
            _todosService = todosService;
        }

        // ✅ Obtener todas las tareas del usuario actual
        [HttpGet]
        [SwaggerOperation(summary: "Obtener todas las tareas del usuario")]
        public async Task<ActionResult<List<Todos>>> GetAllUsers(Guid IdUser)
        {
            var todos = await _todosService.GetAllTodos(IdUser);
            return Ok(todos);
        }

        // ✅ Obtener una tarea por ID
        [HttpGet("{id}")]
        [SwaggerOperation(summary: "Obtener una tarea por id")]
        public async Task<ActionResult<Todos>> GetTodoById(Guid id)
        {
            var todo = await _todosService.getTodoById(id);
            if (todo == null)
            {
                return NotFound(new { message = "Tarea no encontrado" });
            }
            return Ok(todo);
        }

        // ✅ Crear tarea
        [Authorize]
        [HttpPost]
        [SwaggerOperation(summary: "Crear una tarea")]
        public async Task<ActionResult<bool>> CreateTodo([FromBody] CreateTodoDto todoDto)
        {
            var result = await _todosService.createtodo(todoDto);
            if (!result)
            {
                return NotFound(new { message = "Tarea no encontrada" });
            }

            return Ok(new { message = "Tarea creada correctamente" });
        }

        // ✅ Actualizar tarea
        [Authorize]
        [HttpPut("{id}")]
        [SwaggerOperation(summary: "Actualizar tarea")]
        public async Task<ActionResult<bool>> UpdateTodo(Guid id, [FromBody] Todos todo)
        {
            if (id != todo.Id)
            {
                return BadRequest(new { message = "El ID de la tarea no coincide" });
            }

            var result = await _todosService.updateTodo(todo);
            if (!result)
            {
                return NotFound(new { message = "Tarea no encontrada" });
            }

            return Ok(new { message = "Tarea actualizada correctamente" });
        }

        // ✅ procesar tarea
        [Authorize]
        [HttpGet("process/{id}")]
        [SwaggerOperation(summary: "procesar tarea del usuario")]
        public async Task<ActionResult<bool>> ProcessTask(Guid id)
        {
            var result = await _todosService.processTask(id);
            if (!result)
            {
                return NotFound(new { message = "Tarea no encontrada" });
            }

            return Ok(new { message = "Tarea procesada correctamente" });
        }

        // ✅ Borrado lógico de tarea
        [Authorize]
        [HttpDelete("{id}")]
        [SwaggerOperation(summary: "Borrado logico de tarea")]
        public async Task<ActionResult<bool>> DeleteTodo(Guid id)
        {
            var result = await _todosService.deleteTodo(id);
            if (!result)
            {
                return NotFound(new { message = "Tarea no encontrada" });
            }

            return Ok(new { message = "Tarea eliminada correctamente" });
        }
    }
}
