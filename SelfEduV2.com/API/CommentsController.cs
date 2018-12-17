using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SelfEduV2.com.Models;
using SelfEduV2.com.Models.DTOs;

namespace SelfEduV2.com.API
{
    public class CommentsController : ApiController
    {
        private SelfEduContext db = new SelfEduContext();

        // GET: api/Comments
        public IQueryable<CommentDTO> GetCommentDTOes()
        {
            return db.CommentDTOes;
        }

        // GET: api/Comments/5
        [ResponseType(typeof(CommentDTO))]
        public async Task<IHttpActionResult> GetCommentDTO(int id)
        {
            CommentDTO commentDTO = await db.CommentDTOes.FindAsync(id);
            if (commentDTO == null)
            {
                return NotFound();
            }

            return Ok(commentDTO);
        }

        // PUT: api/Comments/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCommentDTO(int id, CommentDTO commentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != commentDTO.Id)
            {
                return BadRequest();
            }

            db.Entry(commentDTO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentDTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Comments
        [ResponseType(typeof(CommentDTO))]
        public async Task<IHttpActionResult> PostCommentDTO([FromBody] CommentDTO commentDTO)
        {
            
            var vidId = commentDTO.Video_id;
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if the user comment is equal to minus 1 then it is a comment on a video
            //else if the id is greater than 0 then it is a reply to a comment
            if (commentDTO.Id == -1)
            {
                UserComments userComment = new UserComments
                {
                    Comment = commentDTO.Comment,
                    UserName = User.Identity.Name
                };
                var video = db.Videos.Find(vidId);
                video.Comments.Add(userComment);
            }
            else {
                UserComments userComment = new UserComments
                {
                    Comment = commentDTO.Comment,
                    UserName = User.Identity.Name
                };

                var comment = db.UserComments.Find(commentDTO.Id);
                comment.Replies.Add(userComment);
            }
            
            await db.SaveChangesAsync();
            
            return Ok("success");
        }

        // DELETE: api/Comments/5
        [ResponseType(typeof(CommentDTO))]
        public async Task<IHttpActionResult> DeleteCommentDTO(int id)
        {
            CommentDTO commentDTO = await db.CommentDTOes.FindAsync(id);
            if (commentDTO == null)
            {
                return NotFound();
            }

            db.CommentDTOes.Remove(commentDTO);
            await db.SaveChangesAsync();

            return Ok(commentDTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CommentDTOExists(int id)
        {
            return db.CommentDTOes.Count(e => e.Id == id) > 0;
        }
    }
}