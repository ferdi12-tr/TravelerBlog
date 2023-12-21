using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelerBlog.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime BlogCreatedDate { get; set; }

        public List<CommentPostRelation> CommentPostRelations { get; set; }
        public List<BlogCityRelation> BlogCityRelations { get; set; }

        public List<BlogLike> BlogLikes { get; set; }
    }
}