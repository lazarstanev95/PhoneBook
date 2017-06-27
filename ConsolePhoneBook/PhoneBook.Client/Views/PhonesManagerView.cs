using PhoneBook.Data.Repositories;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Client.Views
{
    public class PhonesManagerView
    {
        private Contact contact = null;

        public PhonesManagerView(Contact contact)
        {
            this.contact = contact;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Phones management (" + this.contact.FullName + ")");
                Console.WriteLine("ID:" + contact.Id);
                Console.WriteLine("Name :" + contact.FullName);
                Console.WriteLine("Email :" + contact.Email);
                Console.WriteLine("##########################");
                Console.WriteLine("[G]et all Phones");
                Console.WriteLine("[C]reate Phone");
                Console.WriteLine("[D]elete Phone");
                Console.WriteLine("[E]xit");

                string choice = Console.ReadLine();
                switch (choice.ToUpper())
                {
                    case "G":
                        {
                            GetAll();
                            break;
                        }
                    case "C":
                        {
                            Create();
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
                            Console.WriteLine("Invalid choice.");
                            Console.ReadKey(true);
                            break;
                        }
                }
            }
        }

        private void GetAll()
        {
            Console.Clear();
            PhonesRepository phonesRepository = new PhonesRepository();
            List<Phone> phones = phonesRepository.GetAll(this.contact.Id);

            foreach (Phone phone in phones)
            {
                Console.WriteLine("ID: " + phone.Id);
                Console.WriteLine("Phone number: " + phone.PhoneNumber);
            }

            Console.ReadKey(true);
        }

        private void Create()
        {
            PhonesRepository phonesRepository = new PhonesRepository();
            Phone phone = new Phone();
            phone.ParentContactId = this.contact.Id;

            Console.WriteLine("Add new Phone:");
            Console.Write("Phone: ");
            phone.PhoneNumber = Console.ReadLine();

            phonesRepository.Save(phone);

            Console.WriteLine("Phone saved successfully.");
            Console.ReadKey(true);
        }

        private void Delete()
        {
            Console.Clear();

            PhonesRepository phonesRepository = new PhonesRepository();

            Console.WriteLine("Delete Phone:");
            Console.Write("Phone Id: ");
            int phoneId = Convert.ToInt32(Console.ReadLine());

            Phone phone = phonesRepository.GetById(phoneId);
            if (phone == null)
            {
                Console.WriteLine("Phone not found!");
            }
            else
            {
                phonesRepository.Delete(phone);
                Console.WriteLine("Phone deleted successfully.");
            }
            Console.ReadKey(true);
        }
    }
}
