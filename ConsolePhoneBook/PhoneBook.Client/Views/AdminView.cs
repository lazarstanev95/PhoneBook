using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Client.Views
{
    public class AdminView
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Administration:");
                Console.WriteLine("Manage [U]sers");
                Console.WriteLine("Manage [C]ontacts");
                Console.WriteLine("[E]xit");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "U":
                        {
                            UserManagerView userManagerView = new UserManagerView();
                            userManagerView.Show();
                            break;
                        }
                    case "C":
                        {
                            ContactsManagerView contactManagerView = new ContactsManagerView();
                            contactManagerView.Show();
                            break;
                        }
                    case "E":
                        {
                            return;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }
    }
}
