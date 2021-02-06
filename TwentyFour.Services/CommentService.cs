using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;

namespace TwentyFour.Services
{
    public class CommentService
    {
        private readonly Guid _userID;

        public CommentService(Guid userid)
        {
            _userID = userid;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    AuthorID = _userID,
                    PostID = model.PostID,
                    Text = model.Text
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comment
                        .Where(e => e.AuthorID == _userID)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    Author = e.AuthorID,
                                    Text = e.Text,
                                }
                        );

                return query.ToArray();
            }
        }
        public CommentDetail GetCommentByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentID == id && e.AuthorID == _userID);
                return
                    new CommentDetail
                    {
                        CommentID = entity.CommentID,
                        Text = entity.Text,
                        Author = entity.AuthorID,
                        CreatedUtc = entity.CreatedUtc
                    };
            }
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentID == model.CommentID && e.AuthorID == _userID);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int noteID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentID == noteID && e.AuthorID == _userID);

                ctx.Comment.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
