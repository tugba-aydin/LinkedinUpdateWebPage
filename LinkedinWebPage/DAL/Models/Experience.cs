using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Experience
    {
        public int Id { get; set; }
        public string ExperienceTitle { get; set; }
        public string EmploymentType { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Sector { get; set; }
        public string Explanation { get; set; }
        public int UserId { get; set; }
    }
}
