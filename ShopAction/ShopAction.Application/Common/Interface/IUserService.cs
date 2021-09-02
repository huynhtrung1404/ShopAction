using System.Threading.Tasks;
using ShopAction.Application.Dtos;

namespace ShopAction.Application.Common.Interface
{
    public interface IUserService
    {
        Task<bool> RegisterAsync(RegisterAccountDto registerAccount);
        Task<string> SignInAsync(UserLoginDto user);
    }
}
