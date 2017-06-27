using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Repositories
{
    public class ContactsRepository
    {
        private PhoneBookDBContext Context;

        public ContactsRepository()
        {
            this.Context = new PhoneBookDBContext();
        }

        public Contact GetById(int id)
        {
            Contact contact = Context.Contacts.Find(id);
            return contact;
        }

        public List<Contact> GetAll()
        {
            return Context.Contacts.ToList();
        }

        public List<Contact> GetAll(int parentUserId)
        {
            return Context.Contacts.Where(c => c.ParentUserId == parentUserId).ToList();
        }

        public void Save(Contact contact)
        {
            if (contact.Id <= 0)
            {
                Context.Contacts.Add(contact);
                Context.SaveChanges();
            }
            else
            {
                Context.Entry(contact).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void Delete(Contact contact)
        {
            Context.Entry(contact).State = EntityState.Deleted;
            Context.Contacts.Remove(contact);
            Context.SaveChanges();
        }
    }
}
