using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelerBlog.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public DateTime BlogCommentDate { get; set; }
        public string Comment { get; set; }
        public bool Status { get; set; }

        public List<CommentPostRelation> CommentPostRelations { get; set; }
    }
}