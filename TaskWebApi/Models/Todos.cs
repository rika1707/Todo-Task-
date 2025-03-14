namespace TaskWebApi.Models
{
    public class Todos
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
        public required string Estado { get; set; } = "Pendiente";
        public bool IsComplete { get; set; } = false;

        public bool IsDelete { get; set; } = false;

    }
}
