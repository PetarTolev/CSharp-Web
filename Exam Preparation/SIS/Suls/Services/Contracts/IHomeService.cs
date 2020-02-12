namespace Suls.Services.Contracts
{
    using ViewModels.Home;

    public interface IHomeService
    {
        LoggedInViewModel GetLoggedInModel();
    }
}