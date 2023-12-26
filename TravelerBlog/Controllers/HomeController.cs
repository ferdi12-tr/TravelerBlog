using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelerBlog.Entity;

namespace TravelerBlog.Controllers
{
    public class HomeController : Controller
    {
        BlogProcess _blogProcess = new BlogProcess();
        CityProcess _cityProcess = new CityProcess();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RecentBlogPosts()
        {
            var recentPosts = _blogProcess.GetRecentBlogPosts();
            return PartialView(recentPosts);
        }

        //cities according to their blog posts
        public ActionResult PopularCities() 
        {
            var popularCities = _cityProcess.GetPopularCities();
            return PartialView(popularCities);
        }
    }
}