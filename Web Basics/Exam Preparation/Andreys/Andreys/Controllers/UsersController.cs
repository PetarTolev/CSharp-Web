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
            if (this.IsUserLoggedIn())
            {
                return this.Error("You are already logged in!");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(UsersLoginInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Error("You are already logged in!");
            }

            var userId = this.usersService.GetUserId(input);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Error("You are not logged in!");
            }

            this.SignOut();

            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Error("You are already logged in!");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(UsersRegisterInputModel input)
        {
            if (this.IsUserLoggedIn())
            {
                return this.Error("You are already logged in!");
            }
            
            if (input.Password != input.ConfirmPassword ||
                input.Username.Length <= 4 || input.Username.Length >= 10 ||
                input.Password.Length <= 6 || input.Password.Length >= 20 ||
                this.usersService.IsUsernameUsed(input.Username) ||
                this.usersService.IsEmailUsed(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.CreateUser(input);

            return this.Redirect("/");
        }
    }
}
