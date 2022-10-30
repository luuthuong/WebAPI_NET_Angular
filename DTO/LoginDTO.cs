namespace DTO
{
    public class LoginDTO
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsRemember { get; set; } = false;
    }

    public class AuthenticatedResponseDTO {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}