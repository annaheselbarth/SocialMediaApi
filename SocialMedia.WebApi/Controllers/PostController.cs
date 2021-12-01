﻿using Microsoft.AspNet.Identity;
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
    public class PostController : ApiController
    {
        [Authorize]
        public class NoteController : ApiController
        {
            public IHttpActionResult Get()
            {
                PostService postService = CreatePostService();
                var posts = postService.GetPosts();
                return Ok(posts);
            }
            public IHttpActionResult Post(PostCreate post)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreatePostService();

                if (!service.CreatePost(post))
                    return InternalServerError();

                return Ok();
            }
            private PostService CreatePostService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var postService = new PostService(userId);
                return postService;
            }
            public IHttpActionResult Get(int id)
            {
                PostService postService = CreatePostService();
                var post = postService.GetPostById(id);
                return Ok(post);
            }
            public IHttpActionResult Put(PostEdit post)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var service = CreatePostService();

                if (!service.UpdatePost(post))
                    return InternalServerError();

                return Ok();
            }
            public IHttpActionResult Delete(int id)
            {
                var service = CreatePostService();

                if (!service.DeletePost(id))
                    return InternalServerError();

                return Ok();
            }
        }
    }
}
