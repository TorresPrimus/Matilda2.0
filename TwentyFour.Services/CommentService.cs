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
        private readonly Guid _userId;

        public CommentService(Guid userid)
        {
            _userId = userid;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Author = _userId,
                    Text = model.Text,
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
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    Author = e.Author,
                                    Text = e.Text,
                                }
                        );

                return query.ToArray();
            }
        }
        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentId == id && e.Author == _userId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        Text = entity.Text,
                        Author = entity.Author,
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
                        .Single(e => e.CommentId == model.CommentId && e.Author == _userId);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comment
                        .Single(e => e.CommentId == noteId && e.Author == _userId);

                ctx.Comment.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
