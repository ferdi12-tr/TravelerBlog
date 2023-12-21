using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TravelerBlog.Models;


namespace TravelerBlog.Entity
{
    public class DataContext : DbContext
    {
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogComment> BlogComments { get; set; }
        public DbSet<BlogLike> BlogLikes { get; set; }
        public DbSet<BlogCityRelation> BlogCityRelations { get; set; }

        public DbSet<CommentPostRelation> CommentPostRelations { get; set; }


        public DataContext() : base("DbConnection")
        {

        }
    }
}