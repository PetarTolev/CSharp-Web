namespace Andreys.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ProductsController : Controller
    {
        public ProductsController()
        {
            
        }

        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(string name, string description, string imageUrl, string category, string gender, decimal price) //todo: export in inputmodel
        {
            return this.View();
        }

        public HttpResponse Details()
        {
            return this.View();
        }
    }
}
