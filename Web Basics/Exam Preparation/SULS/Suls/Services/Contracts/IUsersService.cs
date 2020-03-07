namespace Suls.Services.Contracts
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsUsernameUsed(string inputUsername);

        bool IsEmailUsed(string inputEmail);
    }
}