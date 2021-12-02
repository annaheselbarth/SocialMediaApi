using Microsoft.AspNet.Identity;
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
    public class CommentController : ApiController
    {
        [Authorize]

        public IHttpActionResult Get(int id)
        {
            CommentService commentService = CreateCommentService();
            var comment = commentService.GetCommentByAuthorId(id);
            return Ok(comment);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }

        private CommentService CreateCommentService()
        {
            var commentId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(commentId);
            return commentService;
        }

        public IHttpActionResult Get()//int commentId
        {
            CommentService commentService = CreateCommentService();
            var note = commentService.GetComment();//commentId
            return Ok(note);
        }
        public IHttpActionResult Get(int postId, int commentId)//int commentId
        {
            CommentService commentService = CreateCommentService();
            var note = commentService.GetCommentByPostId(postId, commentId);//commentId
            return Ok(note);
        }

        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.UpdateComment(comment))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int commentId)
        {
            var service = CreateCommentService();

            if (!service.DeleteComment(commentId))
                return InternalServerError();

            return Ok();
        }
    }

}
