using KUSYS.Business.Abstracts;
using KUSYS.DataAccess.Abstracts;
using KUSYS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUSYS.Business.Concretes
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repo)
        {
            this.repo = repo;
        }

        public List<User> GetAllUsers()
        {
            return repo.GetIQueryableObject<User>().ToList();
        }
        public int CreateUser(User user)
        {
            repo.Add(user);
            return repo.SaveChanges();
        }

        public int DeleteUser(int id)
        {
            var user = GetUserById(id);
            repo.Remove(user);
            return repo.SaveChanges();
        }
        public int DeleteUser(User user)
        {
            repo.Remove(user);
            return repo.SaveChanges();
        }

        public User GetUser(string username, string pasword)
        {
            return repo.GetEntityObject<User>(x => x.UserName == username && x.Password == pasword);
        }
        public Role GetRoleByUserId(int userId)
        {
            var result = (from r in repo.GetIQueryableObject<Role>()
                          join u in repo.GetIQueryableObject<User>() on r.RoleId equals u.RoleId
                          where u.UserId == userId
                          select r).FirstOrDefault();
            return result;
        }
        public User GetUserById(int id)
        {
            return repo.GetEntityObject<User>(id);
        }

        public int UpdateUser(User user)
        {
            repo.Modify(user);
            return repo.SaveChanges();
        }
    }
}
