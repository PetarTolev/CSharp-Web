namespace IRunes.App.Controllers
{
    using InputModels.Users;
    using Services.UsersService;
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
                return this.Redirect("/"); //todo: add message "You are already logged in!"
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.UsernameOrEmail, input.Password);

            if (userId == null)
            {
                return this.Redirect("Login");
            }

            this.SignIn(userId);

            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Redirect("/"); //todo: add message "You are already registered!"
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input) //todo: export to viewmodel
        {
            //TODO: create model for message and show above register form
            string message = null;
            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("Register"); 
            }

            if (this.usersService.IsEmailUsed(input.Email))
            {
                return this.Redirect("Register");
            }

            if (this.usersService.IsUsernameUsed(input.Username))
            {
                return this.Redirect("Register");
            }

            if (input.Username.Length < 4 || input.Username.Length > 10)
            {
                return this.Redirect("Register");
            }

            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Redirect("Register");
            }

            this.usersService.CreateUser(input.Username, input.Password, input.ConfirmPassword, input.Email);

            return this.Redirect("Login");
        }
    }
}
