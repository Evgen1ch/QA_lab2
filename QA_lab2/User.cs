using System;
using System.Collections.Generic;
using System.Text;

namespace QA_lab2
{
    class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public static User CreateValidUser()
        {
            string firstName = FieldGenerator.GenerateValidName();
            string lastName = FieldGenerator.GenerateValidName();
            string email = FieldGenerator.GenerateValidEmail();
            string password = FieldGenerator.GenerateValidPassword();

            return new User(firstName, lastName, email, password);
        }

        public User Copy()
        {
            return new User(FirstName, LastName, Email, Password);
        }
    }
}
