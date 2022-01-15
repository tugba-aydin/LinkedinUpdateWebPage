using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Education
    {
        public int Id { get; set; }
        public string SchoolName { get; set; }
        public string Degree { get; set; }
        public string Department{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Note { get; set; }
        public string ActivitiesandCommunities { get; set; }
        public string Explanation { get; set; }
        public int UserId { get; set; }
    }
}
