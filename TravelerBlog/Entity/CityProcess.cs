using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TravelerBlog.Models;

namespace TravelerBlog.Entity
{
    public class CityProcess
    {
        DataContext _db = new DataContext();

        public BlogCityRelation AddBlogCityRelation(int cityId, int blogPostId)
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public City GetCityById(int cityId)
        {
            try
            {
                return _db.Cities.Find(cityId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<City> GetPopularCities()
        {
            try
            {
                var result = _db.BlogCityRelations
                    .GroupBy(y => y.CityId)
                    .Select(group => new
                    {
                        CityId = group.Key,
                        CityCount = group.Count()
                    })
                    .OrderByDescending(dc => dc.CityCount)
                    .Take(4).ToList();

                List<City> popularCities = new List<City>();
                foreach (var c in result)
                {
                    var city = GetCityById(c.CityId);
                    popularCities.Add(city);
                }
                return popularCities;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}