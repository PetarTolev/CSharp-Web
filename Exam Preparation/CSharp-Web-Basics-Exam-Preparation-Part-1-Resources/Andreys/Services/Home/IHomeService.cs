namespace Andreys.Services.Home
{
    using Models;
    using System.Collections.Generic;

    public interface IHomeService
    {
        IEnumerable<Product> GetAllProducts();
    }
}