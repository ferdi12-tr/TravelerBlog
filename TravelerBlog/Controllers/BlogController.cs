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
    public class BlogController : Controller
    {
        DataContext _db = new DataContext();
        BlogProcess _blogProcess = new BlogProcess();
        UserProcess _userProcess = new UserProcess();

        [Authorize]
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

            var city = _db.Cities.Find(cityId);
            ViewBag.CityName = city.CityName;

            var relation = _db.BlogCityRelations
                                .Where(x => x.CityId == cityId)
                                .Include(x => x.BlogPost).ToList();

            if (relation.Count == 0 || city == null)
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
            ViewBag.CurrentBlogId = blogPostId; // to get comments about that blogpost
            return View(blogPost);
        }

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

        [HttpPost]
        public ActionResult AddComment(string comment, int currentBlogId)
        {
            BlogComment blogComment = new BlogComment()
            {
                Comment = comment,
                BlogCommentDate = DateTime.Now,
                Status= true,
            };
            var addedComment = _blogProcess.AddComment(blogComment);


            var user = _userProcess.Get(User.Identity.Name);
            CommentPostRelation relation = new CommentPostRelation() 
            { 
                UserId = user.Id,
                BlogCommentId = addedComment.Id,
                BlogPostId = currentBlogId
            };

            _blogProcess.AddCommentPostRelation(relation);
            return RedirectToAction("ReadBlogPost", new { blogPostId = currentBlogId });
            
        }
    }
}