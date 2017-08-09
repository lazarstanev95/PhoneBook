using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Data.Repositories
{
    public class UsersRepository
    {
        private PhoneBookDBContext Context;

        public UsersRepository()
        {
            this.Context = new PhoneBookDBContext();
        }

        public List<User> GetAll()
        {
            return Context.Users.ToList();
        }

        public User GetById(int id)
        {
            User user = Context.Users.Find(id);
            return user;
        }

        public void Save(User user)
        {
            if (user.Id <= 0)
            {
                Context.Users.Add(user);
                Context.SaveChanges();
            }
            else
            {
                Context.Entry(user).State = EntityState.Modified;
                Context.SaveChanges();
            }
        }

        public void Delete(User user)
        {
            Context.Entry(user).State = EntityState.Deleted;
            Context.Users.Remove(user);
            Context.SaveChanges();
        }

        public bool IsUsernameExist(string username)
        {
            var v = Context.Users.Where(u => u.Username == username).FirstOrDefault();
            return v != null;
        }
    }
}
