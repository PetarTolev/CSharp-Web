namespace Andreys.Services.Products
{
    using Andreys.InputModels.Products;
    using Data;
    using Models;
    using Models.Enums;
    using System;
    using System.Linq;

    public class ProductsService : IProductsService
    {
        private readonly AndreysDbContext db;

        public ProductsService(AndreysDbContext db)
        {
            this.db = db;
        }

        public void AddProduct(ProductsAddInputModel input)
        {
            var product = new Product
            {
                Name = input.Name,
                Description = input.Description,
                ImageUrl = input.ImageUrl,
                Category = Enum.Parse<Category>(input.Category),
                Gender = Enum.Parse<Gender>(input.Gender),
                Price = input.Price,
            };

            this.db.Products.Add(product);
            this.db.SaveChanges();
        }

        public Product GetProduct(string id)
        {
            return this.db.Products.FirstOrDefault(p => p.Id == id); //todo: refactor
        }

        public void DeleteProduct(Product product)
        {
            this.db.Products.Remove(product);
            this.db.SaveChanges();
        }
    }
}
