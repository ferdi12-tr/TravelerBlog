using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelerBlog.Models
{
    public class CommentPostRelation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public int BlogCommentId { get; set; }

        public BlogComment BlogComment { get; set; }
    }
}