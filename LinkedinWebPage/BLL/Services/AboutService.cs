using BLL.Interfaces;
using DAL.Models;
using DAL.Repository;
using DAL.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AboutService : IAboutService
    {
        private readonly IRepository<About> repository;
        private readonly IUnitofWork unitofWork;

        public AboutService(IRepository<About> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }
        public void UpdateAbout(About about)
        {
            repository.Update(about);
            unitofWork.saveChanges();
        }

        public About GetAboutById(int id)
        {
            var about = repository.GetById(id);
            return about;
        }

        public void AddAbout(About about)
        {
            repository.Add(about);
            unitofWork.saveChanges();
        }

        public List<About> GetAllAbout()
        {
            var abouts = repository.GetAll();
            return abouts;
        }
    }
}
