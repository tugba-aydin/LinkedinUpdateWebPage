using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        List<User> GetAllUser();
        User GetUserById(int id);
        void UpdateUserImage(string imagePath,int id);
    }
}
