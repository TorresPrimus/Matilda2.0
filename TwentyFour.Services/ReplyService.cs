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
                    ReplyCommentID = model.ReplyCommentID
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
                            CommentId = e.CommentID,
                            Author = e.AuthorID,
                            ReplyCommentID = e.ReplyCommentID,
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
                        Author = entity.AuthorID,
                        ReplyCommentID = entity.ReplyCommentID,
                        ReplyComment = entity.ReplyComment,
                        CreatedUtc = entity.CreatedUtc

                    };
            }
        }
    }
}