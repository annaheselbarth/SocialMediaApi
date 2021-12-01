using SocialMedia.Data;
using SocialMedia.Models;
using SocialMedia.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialMedia.WebApi.Controllers
{
    public class LikeController : ApiController
    {

        private Like CreateLike()
        {
            var ownerId = Guid.Parse(User.Identity.GetOwnerId());
            var like = new Like(ownerId);
            return like;
        }

        public IHttpActionResult Get()
        {
            LikeService likeService = CreateLikeService();
            var likes = likeService.GetLikes();
            return Ok(likes);
        }
        public IHttpActionResult Post(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLike();

            if (!service.CreateLike(like))
                return InternalServerError();

            return Ok();


        }

        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetOwnerId());
            var LikeService = new LikeService(userId);
            return LikeService;
        }

        public IHttpActionResult Put(LikeEdit like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLikeService();

            if (!service.UpdateLike(like))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int likeId)
        {
            var service = CreateLikeService();

            if (!service.DeleteLike(likeId))
                return InternalServerError();

            return Ok();
        }
    }
}
