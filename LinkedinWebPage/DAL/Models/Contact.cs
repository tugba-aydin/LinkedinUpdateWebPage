using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberType { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public int UserId { get; set; }
    }
}
