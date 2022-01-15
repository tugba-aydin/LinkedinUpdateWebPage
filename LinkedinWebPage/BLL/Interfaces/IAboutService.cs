using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAboutService
    {
        void UpdateAbout(About about);
        About GetAboutById(int id);
        void AddAbout(About about);
        List<About> GetAllAbout();
    }
}
