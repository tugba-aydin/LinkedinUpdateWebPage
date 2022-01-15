using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
   public interface IEducationService
    {
        void AddEducation(Education education);
        void UpdateEducation(Education education);
        void DeleteEducation(int id);
        List<Education> GetAllEducation();
        Education GetEducationById(int id);
    }
}
