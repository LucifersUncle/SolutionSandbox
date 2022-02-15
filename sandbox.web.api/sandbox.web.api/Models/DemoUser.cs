using System.Collections.Generic;

namespace sandbox.web.api.Models
{
    public class DemoUser
    {
        public static List<User> Users = new List<User>()
        {
            new User() {
                Username = "admin",
                EmailAddress = "admin@email.com",
                Password = "Mypassword!",
                Role = "Administrator"},
            new User() {
                Username = "demo",
                EmailAddress = "demo@email.com",
                Password = "Mypassword!",
                Role = "User"},
        };
    }
}
