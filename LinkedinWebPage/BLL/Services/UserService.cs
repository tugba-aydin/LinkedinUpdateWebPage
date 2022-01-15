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
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IUnitofWork unitofWork;
        public UserService(IRepository<User> _repository,IUnitofWork _unitofWork)
        {
            repository = _repository;
            unitofWork = _unitofWork;
        }
        public void AddUser(User user)
        {
            repository.Add(user);
            unitofWork.saveChanges();
        }

        public void DeleteUser(int id)
        {
            repository.Delete(id);
            unitofWork.saveChanges();
        }

        public List<User> GetAllUser()
        {
            var users = repository.GetAll();
            return users;
        }

        public User GetUserById(int id)
        {
            var user = repository.GetById(id);
            return user;
        }

        public void UpdateUser(User user)
        {
            repository.Update(user);
            unitofWork.saveChanges();
        }

        public void UpdateUserImage(string imagePath,int id)
        {
            User user = repository.GetById(id);
            user.Photo = "https://localhost:44346/"+imagePath;
            repository.Update(user);
            unitofWork.saveChanges();
        }
    }
}
