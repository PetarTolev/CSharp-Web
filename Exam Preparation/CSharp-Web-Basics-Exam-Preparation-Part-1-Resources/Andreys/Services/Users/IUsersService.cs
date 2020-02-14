using Andreys.InputModels.Users;

namespace Andreys.App.Services.Users
{
    public interface IUsersService
    {
        bool IsUsernameUsed(string inputUsername);

        bool IsEmailUsed(string inputEmail);

        void CreateUser(UsersRegisterInputModel input);
    }
}