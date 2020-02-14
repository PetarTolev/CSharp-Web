namespace Andreys.Controllers
{
    using Andreys.App.Services.Users;
    using InputModels.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(UsersLoginInputModel input)
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UsersRegisterInputModel input)
        {
            if (input.Password != input.ConfirmPassword ||
                input.Username.Length <= 4 || input.Username.Length >= 10 ||
                input.Password.Length <= 6 || input.Password.Length >= 20 ||
                this.usersService.IsUsernameUsed(input.Username) ||
                this.usersService.IsEmailUsed(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.CreateUser(input);

            return this.View();
        }
    }
}
