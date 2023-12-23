using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TravelerBlog.Entity.Interfaces;
using TravelerBlog.Models;

namespace TravelerBlog.Entity
{
    public class RoleProcess : ICrud<Role>
    {

        DataContext _db = new DataContext();
        public string Add(Role entity)
        {
            try
            {
                var role = _db.Roles.FirstOrDefault(x => x.Id == entity.Id);
                if (role == null)
                {
                    _db.Roles.Add(entity);
                    _db.SaveChanges();
                    return "Successfully added";
                }
                else
                {
                    return "Cannot Add Role";
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Role Get(int id)
        {
            var role = _db.Roles.Find(id);
            if (role != null)
            {
                return role;
            }
            throw new Exception("Cannot find Entity");
        }

        public List<Role> GetAll()
        {
            var roleList = _db.Roles.ToList();
            if (roleList != null)
            {
                return roleList;
            }
            throw new Exception("Cannot Get All Roles");
        }

        public string Update(Role entity, int id)
        {
            throw new NotImplementedException();
        }
    }
}