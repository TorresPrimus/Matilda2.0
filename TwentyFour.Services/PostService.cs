using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;

namespace TwentyFour.Services
{
    public class PostService
    {

        //CREATE POST
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                Title = model.Title,
                Text = model.Title,
                AuthorID = model.AuthorID
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Post.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET POSTS
        public IEnumerable<PostListItems> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Post.Where
                    (e => e.AuthorID == _userId)
                    .Select(e => new PostListItems
                    {
                        ID = e.ID,
                        Title = e.Title,
                        AuthorID = e.AuthorID
                    }
                    );
                return query.ToArray();
            }
        }

        //GET POST BY ID
        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Post
                    .Single(e => e.ID == id && e.AuthorID == _userId);
                return
                    new PostDetail
                    {
                        ID = entity.ID,
                        Title = entity.Title,
                        Text = entity.Text,
                    };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Post
                        .Single(e => e.ID == model.ID && e.AuthorID == _userId);

                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Post
                    .Single(e => e.ID == postId && e.AuthorID == _userId);

                ctx.Post.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
