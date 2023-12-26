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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RecentBlogPosts()
        {
            var recentPosts = _blogProcess.GetRecentBlogPosts();
            return PartialView(recentPosts);
        }
    }
}