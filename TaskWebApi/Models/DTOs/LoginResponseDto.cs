namespace TaskWebApi.Models.DTOs
{
    public class LoginResponseDto
    {
        public bool Exito { get; set; }
        public string Message { get; set; }
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Token { get; set; }
    }
}
