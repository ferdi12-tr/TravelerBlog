using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    }
}