using PhoneBook.Data.Repositories;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Client.Authentication
{
    public static class AuthenticationService
    {
        public static User LoggedUser { get; private set; }

        public static void Authenticate(string username, string password)
        {
            UsersRepository userRepository = new UsersRepository();
            LoggedUser = userRepository.GetAll()
                .Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
    }
}
