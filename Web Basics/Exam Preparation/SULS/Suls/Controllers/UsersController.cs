namespace Suls.Controllers
{
    using Services.Contracts;
    using SIS.HTTP;
    using SIS.HTTP.Logging;
    using SIS.MvcFramework;
    using System;
    using System.Net.Mail;
    using ViewModels;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly ILogger logger;

        public UsersController(IUsersService usersService, ILogger logger)
        {
            this.usersService = usersService;
            this.logger = logger;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(string username, string password)
        {
            var userId = usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Redirect("/Users/Login");
            }
            
            this.SignIn(userId);

            return this.Redirect("/Home/IndexLoggedIn");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (input.Password != input.ConfirmPassword)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Username?.Length < 5 || input.Username?.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (input.Password?.Length < 6 || input.Password?.Length > 20)
            {
                return this.Redirect("/Users/Register");
            }

            if (!this.IsValidEmail(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            if (usersService.IsUsernameUsed(input.Username))
            {
                return this.Redirect("/Users/Register");
            }

            if (usersService.IsEmailUsed(input.Email))
            {
                return this.Redirect("/Users/Register");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);

            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }

        private bool IsValidEmail(string emailAddress)
        {
            try
            {
                new MailAddress(emailAddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}