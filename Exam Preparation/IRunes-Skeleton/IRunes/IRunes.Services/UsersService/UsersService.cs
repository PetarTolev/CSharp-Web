namespace IRunes.Services.UsersService
{
    using Data;
    using Models;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly RunesDbContext db;

        public UsersService(RunesDbContext db)
        {
            this.db = db;
        }

        public bool IsEmailUsed(string email)
        {
            return this.db.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameUsed(string username)
        {
            return this.db.Users.Any(u => u.Username == username);
        }

        public void CreateUser(string username, string password, string confirmPassword, string email)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password),
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password) //todo: change username parameter name to usernameOrEmail
        {
            var hashedPassword = this.Hash(password);

            return this.db.Users
                    .Where(u => u.Username == username || u.Email == username && u.Password == hashedPassword)
                    .Select(u => u.Id)
                    .FirstOrDefault();
        }

        private string Hash(string input)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
