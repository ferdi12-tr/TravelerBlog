﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelerBlog.Entity;

namespace TravelerBlog.Controllers
{
    public class CityController : Controller
    {
        DataContext db = new DataContext();
        public ActionResult Index()
        {
            return View(db.Cities);
        }
    }
}