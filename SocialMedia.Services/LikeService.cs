using SocialMedia.Data;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Services
{
    public class LikeService
    {

        private readonly Guid _ownerId;
        // private readonly Guid _postId;

        public LikeService(Guid ownerId)
        {
            _ownerId = ownerId;
        }


        public bool CreateLike(LikeCreate model)
        {
            var entity =
                new Like()
                {
                    OwnerId = _ownerId

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Likes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LikeListItem> GetLikes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Likes
                    .Where(e => e.OwnerId == _ownerId)
                    .Select(
                        e =>
                        new LikeListItem
                        {
                            LikeId = e.LikeId
                        }
                     );
                return query.ToArray();
            }
        }

        public LikeDetail GetLikeByPostId(int likePostId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Likes
                    .Single(e => e.LikeId == likePostId && e.PostId == _postId);
                return
                    new LikeDetail
                    {
                        LikeId = entity.LikeId
                    };
            }
        }



        public LikeDetail GetLikeByOwnerId(int likeOwnerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Likes
                    .Single(e => e.LikeId == likeOwnerId && e.OwnerId == _ownerId);
                return
                    new LikeDetail
                    {
                        LikeId = entity.LikeId
                    };
            }
        }
        public bool UpdateLike(LikeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Likes
                        .Single(e => e.LikeId == model.LikeId && e.OwnerId == _ownerId);


                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLike(int likeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Likes
                    .Single(e => e.LikeId == likeId && e.OwnerId == _ownerId);

                ctx.Likes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
