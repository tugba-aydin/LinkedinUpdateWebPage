using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class User
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
