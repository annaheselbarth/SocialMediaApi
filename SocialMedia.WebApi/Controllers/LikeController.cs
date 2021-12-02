using Microsoft.AspNet.Identity;
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
    [Authorize]
    public class LikeController : ApiController
    {

        //private Like CreateLike()
        //{
        //    var ownerId = Guid.Parse(User.Identity.GetUserId());
        //    var like = new LikeService(ownerId);
        //    return like;
        //}

        public IHttpActionResult Get()
        {
            LikeService likeService = CreateLikeService();
            var likes = likeService.GetLikes();
            return Ok(likes);
        }
        public IHttpActionResult Get(int likeId, int postId)
        {
            LikeService likeService = CreateLikeService();
            var reply = likeService.GetLikeByPostId(likeId, postId);
            return Ok(reply);
        }
        public IHttpActionResult Get(int id)
        {
            LikeService likeService = CreateLikeService();
            var reply = likeService.GetLikeByOwnerId(id);
            return Ok(reply);
        }
        public IHttpActionResult Post(LikeCreate like)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLikeService();

            if (!service.CreateLike(like))
                return InternalServerError();

            return Ok();


        }

        private LikeService CreateLikeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
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
