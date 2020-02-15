namespace Andreys.Controllers
{
    using InputModels.Products;
    using Services.Products;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using ViewModels.Products;

    public class ProductsController : Controller
    {
        private readonly IProductsService productsService;

        public ProductsController(IProductsService productsService)
        {
            this.productsService = productsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductsAddInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length <= 4 || input.Name.Length >= 20 || input.Name == null ||
                input.Description.Length >= 10 || input.Description == null ||
                input.Price < 0 ||
                input.Category == null || input.Gender == null)
            {
                return this.Redirect("/Products/Add");
            }

            this.productsService.AddProduct(input);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.productsService.GetProduct(id);

            if (product == null)
            {
                return this.Error("The product does not contains!");
            }

            var model = new ProductDetailsViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category.ToString(),
                Gender = product.Gender.ToString(),
                Price = product.Price,
                ImageUrl = product.ImageUrl,
            };

            return this.View(model);
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var product = this.productsService.GetProduct(id);

            if (product == null)
            {
                return this.Error("The product does not contains!");
            }

            this.productsService.DeleteProduct(product);

            return this.Redirect("/");
        }
    }
}
