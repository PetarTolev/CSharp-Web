using System;
using SIS.HTTP;
using SIS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        public TripsController()
        {
            
        }

        public HttpResponse All()
        {
            throw new NotImplementedException();
        }

        public HttpResponse Details()
        {
            throw new NotImplementedException();
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string name)
        {
            throw new NotImplementedException();
        }
    }
}
