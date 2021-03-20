using System;
using System.Collections.Generic;
using System.Linq;
using DnpAssignments.Models;

namespace DnpAssignments.Data.Impl
{
    public class UserService : IUser
    {
        private static IList<User> users;

        public UserService()
        {
            users = new[]
            {
                new User
                {
                    password = "123456",
                    Role = "USER",
                    username = "Samara"
                },
                new User
                {
                    password = "123456",
                    Role = "ADMIN",
                    username = "Chaya"
                }
            }.ToList();

        }



        public static User ValidateUser(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.username.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }

        User IUser.ValidateUser(string username, string password)
        {
            return ValidateUser(username, password);
        }
    }
}