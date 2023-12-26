using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelerBlog.Models;

namespace TravelerBlog.Entity
{
    public class CityProcess
    {
        DataContext _db = new DataContext();

        public BlogCityRelation AddBlogCityRelation( int cityId, int blogPostId)
        {
            try
            {
                var relation = _db.BlogCityRelations.Add(new BlogCityRelation { CityId = cityId, BlogPostId = blogPostId });
                _db.SaveChanges();
                return relation;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<City> GetCities()
        {
            try
            {
                return _db.Cities.ToList();
            }
            catch (Exception e )
            {
                throw new Exception(e.Message);
            }
        }
    }
}