using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelerBlog.Models
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        public List<BlogCityRelation> BlogCityRelations { get; set; }
    }
}