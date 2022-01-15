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
    public class ExperienceService : IExperienceService
    {
        private readonly IRepository<Experience> repository;
        private readonly IUnitofWork unitofWork;

        public ExperienceService(IRepository<Experience> _repository,IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }
        public void AddExperience(Experience experience)
        {
            repository.Add(experience);
            unitofWork.saveChanges();
        }

        public void DeleteExperience(int id)
        {
            repository.Delete(id);
            unitofWork.saveChanges();
        }

        public List<Experience> GetAllExperience()
        {
            var experiences = repository.GetAll().OrderByDescending(x => x.EndDate).ToList();
            return experiences;
        }

        public Experience GetExperienceById(int id)
        {
            var experience = repository.GetById(id);
            return experience;
        }

        public void UpdateExperience(Experience experience)
        {
            repository.Update(experience);
            unitofWork.saveChanges();
        }
    }
}
