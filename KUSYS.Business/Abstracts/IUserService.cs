using KUSYS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Business.Abstracts
{
    public interface IUserService
    {
        User GetUserById(int id);
        List<User> GetAllUsers();
        User GetUser(string username,string pasword);
        int CreateUser(User user);
        int UpdateUser(User user);
        int DeleteUser(int id);
        int DeleteUser(User user);
        Role GetRoleByUserId(int userId);
    }
}
