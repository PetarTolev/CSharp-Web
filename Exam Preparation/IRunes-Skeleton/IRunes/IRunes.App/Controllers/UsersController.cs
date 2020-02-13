namespace IRunes.App.Controllers
{
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
        public HttpResponse Login(string username, string password) //todo: export to view model with usernameOrEmail
        {
            var userId = this.usersService.GetUserId(username, password);

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
        public HttpResponse Register(string username, string password, string confirmPassword, string email) //todo: export to viewmodel
        {
            //TODO: create model for message and show above register form
            string message = null;
            if (password != confirmPassword)
            {
                return this.Redirect("Register"); 
            }

            if (this.usersService.IsEmailUsed(email))
            {
                return this.Redirect("Register");
            }

            if (this.usersService.IsUsernameUsed(username))
            {
                return this.Redirect("Register");
            }

            if (username.Length < 4 || username.Length > 10)
            {
                return this.Redirect("Register");
            }

            if (password.Length < 6 || password.Length > 20)
            {
                return this.Redirect("Register");
            }

            this.usersService.CreateUser(username, password, confirmPassword, email);

            return this.Redirect("Login");
        }
    }
}
