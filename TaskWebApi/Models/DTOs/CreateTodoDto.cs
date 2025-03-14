namespace TaskWebApi.Models.DTOs
{
    public class CreateTodoDto
    {
        public Guid UserId { get; set; }
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
    }
}
