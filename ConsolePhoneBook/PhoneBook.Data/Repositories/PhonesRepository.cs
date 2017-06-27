using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Repositories
{
    public class PhonesRepository
    {
        private PhoneBookDBContext Context;

        public PhonesRepository()
        {
            this.Context = new PhoneBookDBContext();
        }

        public Phone GetById(int id)
        {
            Phone phone = Context.Phones.Find(id);
            return phone;
        }

        public List<Phone> GetAll()
        {
            return Context.Phones.ToList();
        }

        public List<Phone> GetAll(int parentContactId)
        {
            return Context.Phones.Where(p => p.ParentContactId == parentContactId).ToList();
        }

        public void Save(Phone phone)
        {
            if (phone.Id <= 0)
            {
                Context.Phones.Add(phone);
                Context.SaveChanges();
            }
            else
            {
                Context.Entry(phone).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void Delete(Phone phone)
        {
            Context.Entry(phone).State = EntityState.Deleted;
            Context.Phones.Remove(phone);
            Context.SaveChanges();
        }
    }
}
