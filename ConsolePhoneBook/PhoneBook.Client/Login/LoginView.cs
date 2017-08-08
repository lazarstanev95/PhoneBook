using PhoneBook.Client.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Client.Login
{
    public class LoginView
    {
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();

                AuthenticationService.Authenticate(username, Crypto.Crypto.Hash(password));

                if (AuthenticationService.LoggedUser != null)
                {
                    Console.WriteLine("Hello " + AuthenticationService.LoggedUser.Username);
                    Console.ReadKey(true);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong username or password!");
                }
            }
        }
    }
}
