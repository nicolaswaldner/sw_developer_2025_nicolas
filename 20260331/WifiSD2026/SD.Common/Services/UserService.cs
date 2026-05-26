using SD.Core.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SD.Common.Services
{
    public class UserService : IUserService
    {
        // Mockups für User anlegen

        private readonly List<User> users = [

            new User{
                Id = Guid.NewGuid(),
                FirstName = "Test",
                LastName = "User",
                UserName = "Test",
                Password = new NetworkCredential("Test", "12345").SecurePassword
            }
        ];

        public async Task<User> Authenticate(string username, string password, CancellationToken cancellation)
        {
            //true heißt, dass die Groß- und Kleinschreibung bei User egal ist         \,
            var user = users.SingleOrDefault(w => string.Compare(w.UserName, username, true) == 0 
                                                  && new NetworkCredential(w.UserName, w.Password).Password == password); //eingegebenes Passwort mit dem gespeicherten Passwort vergleichen

            if (user == null)
            {
                return user;
            }

            return await Task.FromResult(user.UserWithoutPassword);
        }
    }
}
