namespace Andreys.Services.Products
{
    using Andreys.InputModels.Products;
    using Models;

    public interface IProductsService
    {
        void AddProduct(ProductsAddInputModel input);

        Product GetProduct(string id);

        void DeleteProduct(Product product);
    }
}