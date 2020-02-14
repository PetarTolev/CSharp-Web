using System.Collections.Generic;
using System.Linq;
using Andreys.Models;

namespace Andreys.Services.Home
{
    using Data;

    public class HomeService : IHomeService
    {
        private readonly AndreysDbContext db;

        public HomeService(AndreysDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.db.Products; //todo: refactor
        }
    }
}
