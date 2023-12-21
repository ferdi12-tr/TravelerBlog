using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelerBlog.Models
{
    public class BlogCityRelation
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
    }
}