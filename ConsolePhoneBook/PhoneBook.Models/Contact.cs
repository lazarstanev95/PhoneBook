using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public int ParentUserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return this.FullName + " (" + this.Email + ")";
        }
    }
}
