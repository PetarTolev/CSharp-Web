using System.IO.IsolatedStorage;

namespace Andreys.App.Services.Users
{
    using Andreys.InputModels.Users;
    using Data;
    using Models;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly AndreysDbContext db;

        public UsersService(AndreysDbContext db)
        {
            this.db = db;
        }

        public bool IsUsernameUsed(string inputUsername)
        {
            return this.db.Users.Any(u => u.Username == inputUsername);
        }

        public bool IsEmailUsed(string inputEmail)
        {
            return this.db.Users.Any(u => u.Email == inputEmail);
        }

        public void CreateUser(UsersRegisterInputModel input)
        {
            var user = new User
            {
                Username = input.Username,
                Email = input.Email,
                Password = this.Hash(input.Password),
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(UsersLoginInputModel input)
        {
            return this.db.Users
                .Where(u => u.Username == input.Username && u.Password == this.Hash(input.Password))
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