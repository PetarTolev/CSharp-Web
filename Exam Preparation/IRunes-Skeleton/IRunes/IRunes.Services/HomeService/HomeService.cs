namespace IRunes.Services.HomeService
{
    using Data;
    using System.Linq;

    public class HomeService : IHomeService
    {
        private readonly RunesDbContext db;

        public HomeService(RunesDbContext db)
        {
            this.db = db;
        }

        public string GetUserName(string userId)
        {
            return this.db.Users
                .Where(u => u.Id == userId)
                .Select(u => u.Username)
                .FirstOrDefault();
        }
    }
}
