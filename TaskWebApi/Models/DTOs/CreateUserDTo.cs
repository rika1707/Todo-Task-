namespace TaskWebApi.Models.DTOs
{
    public class CreateUserDTo
    {
        public required string UserName { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
