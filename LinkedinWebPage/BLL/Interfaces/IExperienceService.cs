using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IExperienceService
    {
        void AddExperience(Experience experience);
        void UpdateExperience(Experience experience);
        void DeleteExperience(int id);
        List<Experience> GetAllExperience();
        Experience GetExperienceById(int id);
    }
}
