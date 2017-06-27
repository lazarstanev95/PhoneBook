using PhoneBook.Client.Authentication;
using PhoneBook.Data.Repositories;
using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Client.Views
{
    public class ContactsManagerView
    {
        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Contacts management:");
                Console.WriteLine("[G]et all Contacts");
                Console.WriteLine("[V]iew Contact");
                Console.WriteLine("[C]reate Contact");
                Console.WriteLine("[U]date Contact");
                Console.WriteLine("[D]elete Contact");
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
            ContactsRepository contactsRepository = new ContactsRepository();
            PhonesRepository phonesRepository = new PhonesRepository();
            List<Contact> contacts = contactsRepository.GetAll(AuthenticationService.LoggedUser.Id);

            foreach (Contact contact in contacts)
            {
                Console.WriteLine("ID:" + contact.Id);
                Console.WriteLine("Name :" + contact.FullName);
                Console.WriteLine("Email :" + contact.Email);

                List<Phone> phones = phonesRepository.GetAll(contact.Id);
                foreach (Phone phone in phones)
                {
                    Console.WriteLine("ID:" + phone.Id);
                    Console.WriteLine("Phone :" + phone.PhoneNumber);
                }
                Console.WriteLine("########################################");
                //PhonesManagerView phonesManagerView = new PhonesManagerView(contact);
                //phonesManagerView.Show();
            }

            Console.ReadKey(true);
        }

        private void View()
        {
            Console.Clear();

            Console.WriteLine("Contact ID: ");
            int contactId = Convert.ToInt32(Console.ReadLine());

            ContactsRepository contactsRepository = new ContactsRepository();
            PhonesRepository phonesRepository = new PhonesRepository();

            Contact contact = contactsRepository.GetById(contactId);
            if (contact == null)
            {
                Console.Clear();
                Console.WriteLine("Contact not found.");
                Console.ReadKey(true);
                return;
            }

            PhonesManagerView phonesManagerView = new PhonesManagerView(contact);
            phonesManagerView.Show();
        }

        private void Create()
        {
            ContactsRepository contactsRepository = new ContactsRepository();
            Contact contact = new Contact();
            contact.ParentUserId = AuthenticationService.LoggedUser.Id;

            Console.WriteLine("Add new Contact: ");
            Console.WriteLine("Full name: ");
            contact.FullName = Console.ReadLine();
            Console.WriteLine("Email: ");
            contact.Email = Console.ReadLine();

            contactsRepository.Save(contact);
            Console.WriteLine("Contact saved succesfully.");

            PhonesManagerView phonesManagerView = new PhonesManagerView(contact);
            phonesManagerView.Show();
        }

        private void Update()
        {
            Console.WriteLine("Contact ID: ");
            int contactId = Convert.ToInt32(Console.ReadLine());

            ContactsRepository contactsRepository = new ContactsRepository();
            Contact contact = contactsRepository.GetById(contactId);

            if (contact == null)
            {
                Console.Clear();
                Console.WriteLine("Contact not found.");
                Console.ReadKey(true);
                return;
            }

            Console.WriteLine("Editing contact (" + contact.FullName + ")");
            Console.WriteLine("ID: " + contact.Id);

            Console.WriteLine("Name: " + contact.FullName);
            Console.WriteLine("New name: ");
            string fullName = Console.ReadLine();
            Console.WriteLine("Email: " + contact.Email);
            Console.WriteLine("New email: ");
            string email = Console.ReadLine();

            if (!string.IsNullOrEmpty(fullName))
                contact.FullName = fullName;
            if (!string.IsNullOrEmpty(email))
                contact.Email = email;

            contactsRepository.Save(contact);
            Console.WriteLine("Contact save succesfully.");
            Console.ReadKey(true);

            PhonesManagerView phonesManagerView = new PhonesManagerView(contact);
            phonesManagerView.Show();
        }

        private void Delete()
        {
            Console.WriteLine("Delete contact:");
            Console.Write("Contact ID: ");
            int contactId = Convert.ToInt32(Console.ReadLine());

            ContactsRepository contactsRepository = new ContactsRepository();
            Contact contact = contactsRepository.GetById(contactId);
            if (contact == null)
            {
                Console.WriteLine("Contact not found.");
            }
            else
            {
                contactsRepository.Delete(contact);
                Console.WriteLine("Contact deleted succesfully.");
            }
            Console.ReadKey(true);
        }
    }
}
