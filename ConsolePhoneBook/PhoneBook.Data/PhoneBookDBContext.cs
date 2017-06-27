namespace PhoneBook.Data
{
    using PhoneBook.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhoneBookDBContext : DbContext
    {
        public PhoneBookDBContext()
            : base("name=PhoneBookDBContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Phone> Phones { get; set; }


    }
}