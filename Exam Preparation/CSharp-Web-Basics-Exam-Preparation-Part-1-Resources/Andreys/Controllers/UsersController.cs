namespace Andreys.Controllers
{
    using InputModels.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class UsersController : Controller
    {
        public UsersController()
        {
            
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
            return this.View();
        }
    }
}
