using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelerBlog.Entity;
using TravelerBlog.Models;
using TravelerBlog.Providers;

namespace TravelerBlog.Controllers
{
    public class CommentController : Controller
    {
        DataContext _db = new DataContext();
        public ActionResult DisplayComments(int currentBlogId)
        {
            var result = _db.CommentPostRelations
                            .Where(x => x.BlogPostId == currentBlogId)
                            .Include(x => x.BlogComment)
                            .Include(x => x.User);

            List<UserCommentProvider> comments = new List<UserCommentProvider>();
            foreach (var comment in result) 
            {
                comments.Add(new UserCommentProvider()
                {
                    BlogComment = comment.BlogComment,
                    User = comment.User,
                });
            }
            return PartialView(comments);
        }
    }
}