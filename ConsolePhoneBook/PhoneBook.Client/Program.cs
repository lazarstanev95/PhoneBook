using PhoneBook.Client.Authentication;
using PhoneBook.Client.Login;
using PhoneBook.Client.Views;
using PhoneBook.Data;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBookDBContext context = new PhoneBookDBContext();
            context.Database.Initialize(true);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("[R]egister user");
                Console.WriteLine("[L]ogin");
                Console.WriteLine("[E]xit from program");
                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "R":
                        {
                            RegisterView registerView = new RegisterView();
                            registerView.Show();
                            break;
                        }
                    case "L":
                        {
                            LoginView loginView = new LoginView();
                            loginView.Show();

                            if (AuthenticationService.LoggedUser.IsAdmin)
                            {
                                AdminView adminView = new AdminView();
                                adminView.Show();
                            }
                            else
                            {
                                ContactsManagerView contactsManagerView = new ContactsManagerView();
                                contactsManagerView.Show();
                            }
                            Console.WriteLine("Bye!");
                            Console.ReadKey(true);
                            break;
                        }
                    case "E":
                        {
                            Console.WriteLine("Bye!");
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice!");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
    }
}
