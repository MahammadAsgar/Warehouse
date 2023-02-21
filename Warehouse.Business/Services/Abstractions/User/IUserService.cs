using Warehouse.Business.Dtos.Post.User;
using Warehouse.Business.Results;

namespace Warehouse.Business.Services.Abstractions.User
{
    public interface IUserService
    {
        Task<ServiceResult> GetUser(string userId);
        Task<ServiceResult> AddUser(RegisterUserDto registerUser);
        Task<ServiceResult> Register(RegisterUserDto registerUser);
        Task<ServiceResult> LogIn(LoginUserDto loginUser);
        Task<ServiceResult> LogOut();
        Task<ServiceResult> AddClaim(AddClaimDto claim);
        Task<ServiceResult> GetUsers();
        ServiceResult GetLoggedUser();
        Task PasswordResetAsync(string email);
        Task<bool> VerifyResetTokenAsync(string resetToke, string UserName);
        Task<bool> UpdatePassword(string userName, string resetToken, string newPassword);
        Task<bool> EmailConfirmAsync(string email);
        Task<bool> VerifyConfirmAsync(string userName, string confirmToken);
    }
}
