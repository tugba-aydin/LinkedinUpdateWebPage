using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
   public class Skill
    {
        public int Id { get; set; }
        public string SkillName { get; set; }
        public int UserId { get; set; }
    }
}
