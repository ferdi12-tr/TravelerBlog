using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TravelerBlog.Models;

namespace TravelerBlog.Entity
{
    public class CommentProcess
    {
        DataContext _db = new DataContext();
        public bool ApproveByCommentId(int commentId)
        {
            try
            {
                var comment = _db.BlogComments.Find(commentId);
                comment.Status = true;
                _db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<CommentPostRelation> GetAllPendingComments()
        {
            try
            {
                return _db.CommentPostRelations
                    .Include(x => x.BlogComment)
                    .Include(x => x.User)
                    .Where(x => !x.BlogComment.Status)
                    .ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}