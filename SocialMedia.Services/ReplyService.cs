using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class ReplyService
    {

        private readonly Guid _authorID;
        public ReplyService(Guid authorID)
        {
            _authorID = authorID;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    AuthorID = _authorID,
                    Text = model.Text,
                    //CommentID = model.CommentID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReplies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Replies
                    .Where(e => e.AuthorID == _authorID)
                    .Select(
                        e =>
                        new ReplyListItem
                        {
                            ReplyID = e.ReplyID,
                            Text = e.Text
                        }
                     );
                return query.ToArray();
            }
        }

        public ReplyDetail GetReplyById(int replyId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.ReplyID == replyId && e.AuthorID == _authorID);
                return
                    new ReplyDetail
                    {
                        ReplyID = entity.ReplyID,
                        Text = entity.Text
                    };
            }
        }
        public bool UpdateReply(ReplyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Replies
                        .Single(e => e.ReplyID == model.ReplyID && e.AuthorID == _authorID);
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteReply(int replyId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Replies
                    .Single(e => e.ReplyID == replyId && e.AuthorID == _authorID);

                ctx.Replies.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
