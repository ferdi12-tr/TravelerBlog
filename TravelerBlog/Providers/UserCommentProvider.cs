using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TravelerBlog.Models;

namespace TravelerBlog.Providers
{
    public class UserCommentProvider
    {
        public BlogComment BlogComment { get; set; }
        public User User { get; set; }
    }
}