using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class About
    {
        public int Id { get; set; }
        public string AboutMe { get; set; }
        public int UserId { get; set; }
    }
}
