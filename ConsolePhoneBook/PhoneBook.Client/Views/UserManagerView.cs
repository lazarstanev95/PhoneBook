using PhoneBook.Data.Repositories;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Client.Views
{
    public class UserManagerView
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("[G]et all users");
                Console.WriteLine("[V]iew User");
                Console.WriteLine("[C]reate");
                Console.WriteLine("[U]pdate");
                Console.WriteLine("[D]elete");
                Console.WriteLine("[E]xit");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "G":
                        {
                            GetAll();
                            break;
                        }
                    case "V":
                        {
                            View();
                            break;
                        }
                    case "C":
                        {
                            Create();
                            break;
                        }
                    case "U":
                        {
                            Update();
                            break;
                        }
                    case "D":
                        {
                            Delete();
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

        public void GetAll()
        {
            UsersRepository userRepository = new UsersRepository();
            List<User> users = userRepository.GetAll();

            foreach (User user in users)
            {
                Console.WriteLine("ID:" + user.Id);
                Console.WriteLine("Username :" + user.Username);
                Console.WriteLine("Password :" + user.Password);
                Console.WriteLine("First Name :" + user.FirstName);
                Console.WriteLine("Last Name :" + user.LastName);
                Console.WriteLine("IsAdmin :" + user.IsAdmin);
            }

            Console.ReadKey();
        }

        public void View()
        {
            Console.Clear();

            Console.WriteLine("User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            UsersRepository userRepository = new UsersRepository();
            User user = userRepository.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Username: " + user.Username);
            Console.WriteLine("Password: " + user.Password);
            Console.WriteLine("First name: " + user.FirstName);
            Console.WriteLine("Last name: " + user.LastName);
            Console.WriteLine("Is Admin: " + user.IsAdmin);

            Console.ReadKey();
        }

        public void Create()
        {
            Console.Clear();

            User user = new User();
            Console.WriteLine("Enter username: ");
            user.Username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            user.Password = Console.ReadLine();
            Console.WriteLine("Enter first name: ");
            user.FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name: ");
            user.LastName = Console.ReadLine();
            Console.WriteLine("Is Admin: ");
            user.IsAdmin = Convert.ToBoolean(Console.ReadLine());
            UsersRepository userRepository = new UsersRepository();
            userRepository.Save(user);
            Console.WriteLine("User saved successfully.");
        }

        public void Update()
        {
            Console.Clear();

            Console.WriteLine("User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            UsersRepository userRepository = new UsersRepository();
            User user = userRepository.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Editing User (" + user.Username + ")");
            Console.WriteLine("ID: " + user.Id);

            Console.WriteLine("Username: " + user.Username);
            Console.Write("New Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: " + user.Password);
            Console.WriteLine("New Password: ");
            string password = Console.ReadLine();

            Console.WriteLine("First name: " + user.FirstName);
            Console.WriteLine("New first name: ");
            string firstName = Console.ReadLine();

            Console.WriteLine("Last name: " + user.LastName);
            Console.WriteLine("New last name: ");
            string lastName = Console.ReadLine();

            Console.WriteLine("Is Admin: " + user.IsAdmin);
            Console.WriteLine("New Admin: ");
            string isAdmin = Console.ReadLine();

            if (!string.IsNullOrEmpty(username))
                user.Username = username;
            if (!string.IsNullOrEmpty(password))
                user.Password = password;
            if (!string.IsNullOrEmpty(firstName))
                user.FirstName = firstName;
            if (!string.IsNullOrEmpty(lastName))
                user.LastName = lastName;
            if (!string.IsNullOrEmpty(isAdmin))
                user.IsAdmin = Convert.ToBoolean(isAdmin);

            userRepository.Save(user);
            Console.WriteLine("User saved succesfully.");
            Console.ReadKey(true);
        }

        public void Delete()
        {
            Console.Clear();

            Console.WriteLine("User ID: ");
            int userId = Convert.ToInt32(Console.ReadLine());

            UsersRepository userRepository = new UsersRepository();
            User user = userRepository.GetById(userId);

            if (user == null)
            {
                Console.WriteLine("User not found.");
            }
            else
            {
                userRepository.Delete(user);
                Console.WriteLine("User deleted successfully.");
            }
            Console.ReadKey(true);
        }
    }
}
