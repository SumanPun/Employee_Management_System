using EmployeeManagementSystem.Dtos;
using EmployeeManagementSystem.Responses;

namespace EmployeeManagementSystem.Repositories.Contracts
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAsync(Register user);
        Task<LoginResponse> SignInAsync(Login user);
        Task<LoginResponse> RefreshTokenAsync(RefreshToken token);
    }
}
