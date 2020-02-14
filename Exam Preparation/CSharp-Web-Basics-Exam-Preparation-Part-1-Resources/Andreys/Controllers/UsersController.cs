namespace Andreys.Controllers
{
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
        public HttpResponse Login(string username, string password)
        {
            return this.View();
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password, string confirmPassword) //todo: export in inputmodel
        {
            return this.View();
        }
    }
}
