using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class CommentService
    {
        private readonly Guid _authorId;

        public CommentService(Guid authorId)
        {
            _authorId = authorId;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    CommentId = model.CommentId,
                    Text = model.Text,
                    CreatedUtc = DateTimeOffset.Now

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<CommentListItems> GetComment()//int postId
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.AuthorId == _authorId)
                        .Select(
                        e =>
                        new CommentListItems
                        {
                            CommentId = e.CommentId,
                            Text = e.Text,
                            CreatedUtc = e.CreatedUtc,
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
                        .Comments
                        .Single(e => e.AuthorId == _authorId);
                return
                  new CommentDetail
                  {
                      CommentId = entity.CommentId,
                      Text = entity.Text,
                      CreatedUtc = entity.CreatedUtc,
                      ModifiedUtc = entity.ModifiedUtc
                  };
            }

        }

        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId);

                entity.CommentId = model.CommentId;
                entity.Text = model.Text;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == commentId);
                        ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }
    }
}
