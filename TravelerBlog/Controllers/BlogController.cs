using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelerBlog.Entity;
using TravelerBlog.Models;

namespace TravelerBlog.Controllers
{
    public class BlogController : Controller
    {
        DataContext _db = new DataContext();

        public ActionResult Index()
        {
            // To add blog 
            return View();
        }

        public ActionResult BlogForCity(int cityId = 0) 
        {
            if (cityId == 0)
            {
                return RedirectToAction("Index", "City"); // TO-DO change redirection
            }
            var relation = _db.BlogCityRelations
                                .Where(x => x.CityId == cityId)
                                .Include(x => x.BlogPost).ToList();

            if (relation.Count == 0)
            {
                return RedirectToAction("Index", "City");// TODO change redirection
            }


            List<BlogPost> blogPosts = new List<BlogPost>();
            foreach (var post in relation)
            {
                blogPosts.Add(post.BlogPost);
            }

            return View(blogPosts);
        }

        public ActionResult ReadBlogPost(int blogPostId)
        {
            var blogPost = _db.BlogPosts.Find(blogPostId);
            if (blogPost == null)
            {
                return RedirectToAction("Index", "City");// TODO change redirection
            }
            return View(blogPost);
        }
    }
}