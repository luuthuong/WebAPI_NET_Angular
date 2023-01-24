namespace Backend.Common.Requests
{
    public class RegisterUserRequest
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Guid> RoleIds { get; set; }

        public void Format()
        {
            UserName = UserName?.Trim() ?? string.Empty;
            Email = Email?.Trim() ?? string.Empty;
        }
    }
}
