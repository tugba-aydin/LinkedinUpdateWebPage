using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface ISkillService
    {
        void AddSkill(Skill skill);
        void UpdateSkill(Skill skill);
        void DeleteSkill(int id);
        List<Skill> GetAllSkill();
        Skill GetSkillById(int id);
    }
}
