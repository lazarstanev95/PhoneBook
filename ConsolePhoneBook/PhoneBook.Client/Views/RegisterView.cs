using PhoneBook.Data.Repositories;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Client.Views
{
    public class RegisterView
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[R]egister user");
                Console.WriteLine("[E]xit");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "R":
                        {
                            Create();
                            break;
                        }
                    case "E":
                        {
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

        public void Create()
        {
            User user = new User();
            Console.WriteLine("Enter username: ");
            user.Username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            user.Password = Console.ReadLine();
            user.Password = Crypto.Crypto.Hash(user.Password);
            Console.WriteLine("Enter first name: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Is Admin: ");
            user.IsAdmin = Convert.ToBoolean(Console.ReadLine());
            UsersRepository userRepository = new UsersRepository();
            if (userRepository.IsUsernameExist(user.Username))
            {
                Console.WriteLine("User already exist!");
                Console.ReadKey(true);
                return;
            }

            userRepository.Save(user);
            Console.WriteLine("User saved successfully.");
            Console.ReadKey(true);
        }
    }
}
