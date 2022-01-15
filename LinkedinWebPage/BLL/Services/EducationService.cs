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
    public class EducationService : IEducationService
    {
        private readonly IRepository<Education> repository;
        private readonly IUnitofWork unitofWork;
        public EducationService(IRepository<Education> _repository, IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }
        public void AddEducation(Education education)
        {
            repository.Add(education);
            unitofWork.saveChanges();
        }

        public void DeleteEducation(int id)
        {
            repository.Delete(id);
            unitofWork.saveChanges();
        }

        public List<Education> GetAllEducation()
        {
            var educations = repository.GetAll().OrderByDescending(x=>x.EndDate).ToList();
            return educations;
        }

        public Education GetEducationById(int id)
        {
            var education = repository.GetById(id);
            return education;
        }

        public void UpdateEducation(Education education)
        {
            repository.Update(education);
            unitofWork.saveChanges();
        }
    }
}
