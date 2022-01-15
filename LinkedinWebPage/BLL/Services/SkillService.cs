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
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> repository;
        private readonly IUnitofWork unitofWork;
        public SkillService(IRepository<Skill> _repository,IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }
        public void AddSkill(Skill skill)
        {
            repository.Add(skill);
            unitofWork.saveChanges();
        }

        public void DeleteSkill(int id)
        {
            repository.Delete(id);
            unitofWork.saveChanges();
        }

        public List<Skill> GetAllSkill()
        {
            var skills = repository.GetAll();
            return skills;
        }

        public Skill GetSkillById(int id)
        {
            var skill = repository.GetById(id);
            return skill;
        }

        public void UpdateSkill(Skill skill)
        {
            repository.Update(skill);
            unitofWork.saveChanges();
        }
    }
}
