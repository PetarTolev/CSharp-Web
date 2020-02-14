namespace Andreys.App.Services.Users
{
    using Data;

    public class UsersService : IUsersService
    {
        private readonly AndreysDbContext db;

        public UsersService(AndreysDbContext db)
        {
            this.db = db;
        }
    }
}