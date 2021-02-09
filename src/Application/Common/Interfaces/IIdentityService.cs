using todo_api.Application.Common.Models;
using System.Threading.Tasks;
using todo_api.Application.ApplicationUser.Queries.Login;

namespace todo_api.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        
        Task<ApplicationUserDto> CheckUserPassword(string email, string password);

        Task<bool> IsInRoleAsync(string userId, string role);

        Task<bool> AuthorizeAsync(string userId, string policyName);

        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);

        Task<Result> DeleteUserAsync(string userId);
    }
}
