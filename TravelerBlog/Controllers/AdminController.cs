using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelerBlog.Entity;
using TravelerBlog.Providers;

namespace TravelerBlog.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        CommentProcess _commentProcess = new CommentProcess();
        public ActionResult Index()
        {
            var result = _commentProcess.GetAllPendingComments();

            List<UserCommentProvider> comments = new List<UserCommentProvider>();
            foreach (var comment in result)
            {
                comments.Add(new UserCommentProvider()
                {
                    BlogComment = comment.BlogComment,
                    User = comment.User,
                });
            }
            return View(comments);
        }

        public ActionResult ApproveComment(int commentId) 
        {
            _commentProcess.ApproveByCommentId(commentId);
            return RedirectToAction("Index");
        }
    }
}