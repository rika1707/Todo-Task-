namespace TaskWebApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public bool IsDelete { get; set; } = false;

    }
}
