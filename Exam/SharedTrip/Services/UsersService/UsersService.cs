namespace SharedTrip.Services.UsersService
{
    using InputModels.Users;
    using Models;
    using Data;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string GetUserId(string username, string password)
        {
            return this.db.Users
                .Where(u => u.Username == username && u.Password == this.Hash(password))
                .Select(u => u.Id)
                .FirstOrDefault();
        }

        public void CreateUser(UsersRegisterInputModel input)
        {
            var user = new User
            {
                Username = input.Username,
                Email = input.Email,
                Password = this.Hash(input.Password),
            };

            this.db.Add(user);
            this.db.SaveChanges();
        }

        public bool IsEmailUsed(string inputEmail)
        {
            return this.db.Users.Any(u => u.Email == inputEmail);
        }

        public bool IsUserNameUsed(string inputUsername)
        {
            return this.db.Users.Any(u => u.Username == inputUsername);
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
