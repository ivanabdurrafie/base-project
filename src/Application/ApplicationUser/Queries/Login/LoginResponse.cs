namespace todo_api.Application.ApplicationUser.Queries.Login
{
    public class LoginResponse
    {
        public ApplicationUserDto User { get; set; }

        public string Token { get; set; }
    }

    public class ApplicationUserDto

    {
    public string Id { get; set; }

    public string UserName { get; set; }

    public string Email { get; set; }
    }
}