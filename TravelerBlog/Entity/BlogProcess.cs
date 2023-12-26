using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using TravelerBlog.Models;

namespace TravelerBlog.Entity
{
    public class BlogProcess
    {
        DataContext _db = new DataContext();
        public BlogComment AddComment(BlogComment comment)
        {
            try
            {
                var addedComment = _db.BlogComments.Add(comment);
                _db.SaveChanges();
                return addedComment;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool AddCommentPostRelation(CommentPostRelation relation)
        {
            try
            {
                _db.CommentPostRelations.Add(relation);
                _db.SaveChanges ();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public BlogPost AddBlogPost(string title, string content)
        {
            try
            {
                var newBlogPost = _db.BlogPosts.Add(new BlogPost()
                {
                    Title = title,
                    Content = content,
                    BlogCreatedDate = DateTime.Now,
                });
                _db.SaveChanges();

                return newBlogPost;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<BlogPost> GetRecentBlogPosts() 
        {
            try
            {
                var recentPosts = _db.BlogPosts.OrderByDescending(p => p.BlogCreatedDate).Take(3).ToList();
                return recentPosts;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}