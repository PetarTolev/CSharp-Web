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
    }
}
