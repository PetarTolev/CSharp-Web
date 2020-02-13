namespace IRunes.Models
{
    using SIS.MvcFramework;
    using System;

    public class User : IdentityUser<string>
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
