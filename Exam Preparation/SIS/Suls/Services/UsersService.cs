namespace Suls.Services
{
    using Contracts;
    using Data;
    using Models;
    using SIS.MvcFramework;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly SULSContext dbContext;

        public UsersService(SULSContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                Username = username,
                Email = email,
                Password = this.Hash(password),
                Role = IdentityRole.User
            };

            this.dbContext.Users.Add(user);
            this.dbContext.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            var hashedPassword = this.Hash(password);
            return this.dbContext.Users
                .Where(u => u.Username == username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();
        }

        public bool IsUsernameUsed(string inputUsername)
        {
            return this.dbContext.Users
                .Any(u => u.Username == inputUsername);
        }

        public bool IsEmailUsed(string inputEmail)
        {
            var a = dbContext.Users.Where(u => u.Email == inputEmail).ToList();

            return this.dbContext.Users
                .Any(u => u.Email == inputEmail);
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
