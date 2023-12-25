using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using TravelerBlog.Entity.Interfaces;
using TravelerBlog.Models;

namespace TravelerBlog.Entity
{
    public class UserProcess : ICrud<User>
    {
        DataContext _db = new DataContext();
        public string Add(User entity)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(u => u.UserName == entity.UserName);
                if (user == null)
                {
                    _db.Users.Add(entity);
                    _db.SaveChanges();
                    return "User Added Successfully";
                }
                return "Cannot Add User";
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public string Delete(int id)
        {
            try
            {
                var user = _db.Users.Find(id);
                if (user != null)
                {
                    _db.Users.Remove(user);
                    _db.SaveChanges();
                    return "Romove User Successfully";
                }
                return "Cannot Remove User";
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public User Get(int id)
        {
            try
            {
                var user = _db.Users.Find(id);
                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public User Get(string email)
        {
            try
            {
                var user = _db.Users.FirstOrDefault(x => x.Email == email);
                return user;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<User> GetAll()
        {
            try
            {
                var userList = _db.Users.ToList();
                return userList;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public string Update(User entity, int id)
        {
            try
            {
                var user = _db.Users.Find(id);
                if (user != null)
                {
                    user.Email = entity.Email;
                    user.UserName = entity.UserName;
                    _db.SaveChanges();
                    return "Update User Successfully";
                }
                return "Cannot Update User";
            }
            catch (Exception e)
            {
            
                throw new Exception(e.Message);
            }
        }

        public string PasswordChange(int id, string oldPsw, string newPsw, string newPswRepeat)
        {
            try
            {
                var user = Get(id);
                if (user != null)
                {
                    if (user.Password == oldPsw)
                    {
                        if (user.Password != newPsw)
                        {
                            if (newPsw == newPswRepeat)
                            {
                                user.Password = newPswRepeat;
                                _db.SaveChanges();
                                return "Password Successfull Changed";
                            }
                            return "Cannot change Password";
                        }
                        return "Wrong Password";
                    }
                    return "Wrong Password";
                }
                return "Create An Account Please";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
    }
}