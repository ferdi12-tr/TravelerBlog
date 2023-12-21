using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelerBlog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public Role Role { get; set; }
        public DateTime UserCreatedDate { get; set; }

        public List<CommentPostRelation> CommentPostRelations { get; set; }

        public List<BlogLike> BlogLikes { get; set; }

    }
}