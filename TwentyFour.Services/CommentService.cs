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

        public CommentService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                AuthorID = model.AuthorID,
                Text = model.Text,
                CommentPostID = model.CommentPostID,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comment.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }



        public IEnumerable<CommentListItem> GetComment()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comment
                        .Where(e => e.AuthorID == _userId)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentID = e.CommentID,
                                    AuthorID = e.AuthorID,
                                    CommentPostID = e.CommentPostID
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
                        .Single(e => e.CommentID == id && e.AuthorID == _userId);
                return
                    new CommentDetail
                    {
                        CommentID = entity.CommentID,
                        Text = entity.Text,
                        AuthorID = entity.AuthorID,
                        CommentPostID = entity.CommentPostID,
                        CommentPostName = entity.CommentPost.Title
                    };
            }
        }


    }

}

