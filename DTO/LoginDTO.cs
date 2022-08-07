namespace DTO
{
    public class LoginDTO
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsRemember { get; set; }
    }

    public class AuthenticatedResponse {
        public string? Token { get; set; }
    }
}