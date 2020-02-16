using System;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
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
        public HttpResponse Login(string username)
        {
            throw new NotImplementedException();
        }

        public HttpResponse Logout()
        {
            throw new NotImplementedException();
        }

        public HttpResponse Register()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public HttpResponse Register(string username)
        {
            throw new NotImplementedException();
        }
    }
}
