using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;

namespace TwentyFour.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        //Post

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    Text = model.Text,
                    CommentID = model.ReplyCommentID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Reply.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GETALL
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Reply
                    .Where(e => e.AuthorID == _userId)
                    .Select(
                    e =>
                        new ReplyListItem
                        {
                            CommentID = e.CommentID,
                            ReplyID = e.ReplyID,
                            PostTitle = e.Comment.Post.Title
                        }
                    );
                return query.ToArray();
            }

        }
        //GET BY ID
        public ReplyDetail GetReplyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx
                    .Reply
                    .Single(e => e.CommentID == id && e.AuthorID == _userId);
                return
                    new ReplyDetail
                    {
                        CommentID = entity.CommentID,
                        Text = entity.Text,
                        ReplyCommentID = entity.ReplyID,
                        ReplyComment = entity.Comment,
                        CreatedUtc = entity.CreatedUtc

                    };
            }
        }
    }
}