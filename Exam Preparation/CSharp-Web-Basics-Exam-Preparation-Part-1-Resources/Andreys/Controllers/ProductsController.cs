namespace Andreys.Controllers
{
    using InputModels.Products;
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
        public HttpResponse Add(ProductsAddInputModel input)
        {
            return this.View();
        }

        public HttpResponse Details()
        {
            return this.View();
        }
    }
}
