using System;
using System.Collections.Generic;
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

            return View(_db.BlogPosts);
        }

        public ActionResult BlogForCity(int id) 
        { 
            return View(id);
        }
    }
}