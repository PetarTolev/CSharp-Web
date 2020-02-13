namespace IRunes.Services.UsersService
{
    public interface IUsersService
    {
        bool IsEmailUsed(string email);

        bool IsUsernameUsed(string username);

        void CreateUser(string username, string password, string confirmPassword, string email);

        string GetUserId(string usernameOrEmail, string password);
    }
}