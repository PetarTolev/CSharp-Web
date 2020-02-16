namespace SharedTrip.Services.UsersService
{
    using InputModels.Users;

    public interface IUsersService
    {
        string GetUserId(string username, string password);

        void CreateUser(UsersRegisterInputModel input);

        bool IsEmailUsed(string inputEmail);

        bool IsUserNameUsed(string inputUsername);
    }
}