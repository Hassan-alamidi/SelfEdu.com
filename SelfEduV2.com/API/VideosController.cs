using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SelfEduV2.com.Models;
using SelfEduV2.com.Models.DTOs;

namespace SelfEduV2.com.API
{
    public class VideosController : ApiController
    {
        private SelfEduContext db = SelfEduContext.Create();

        // GET: api/Videos
        public IQueryable<VideoDTO> GetPopularVideos()
        {

            var vids = (from v in db.Videos orderby v.OverAllRating descending
                        select new VideoDTO
                        {
                            Video_id = v.Video_id,
                            ThumbnailPath = v.ThumbnailPath,
                            Title = v.Title,
                            ChannelId = v.CreatorChannel.Channel_id,
                            Views = v.Views,
                            OverAllRating = v.OverAllRating
                       } ).Take(6);
            
            return vids;
        }

        // GET: api/Videos/5
        [ResponseType(typeof(VideoDTO))]
        public async Task<VideoDTO> GetVideo(int id)
        {
            Video v = await db.Videos.FindAsync(id);
            if (v == null) {
                return null;
            }
            VideoDTO video = new VideoDTO
            {
                Video_id = id,
                Title = v.Title,
                Keywords = v.Keywords,
                Views = v.Views,
                Like = v.Ratings.Count(R => R.IsLike = true),
                Dislike = v.Ratings.Count(R => R.IsLike = false),
                CreatorChannel = v.CreatorChannel,
                Videos = v.CreatorChannel.VideoCollection.Select(Vid => new VideoDTO() {
                    Video_id = Vid.Video_id,
                    ThumbnailPath = Vid.ThumbnailPath,
                    Title = Vid.Title,
                    Views = Vid.Views,
                    OverAllRating = Vid.OverAllRating
                }).Take(10).ToList(),
                Comments = v.Comments.Select(C => new CommentDTO() {
                    Id = C.Id,
                    Comment = C.Comment,
                    UserId = C.UserId,
                    Replies = C.Replies.Select(R => new CommentDTO()
                    {
                        Id = R.Id,
                        Comment = R.Comment,
                        UserId = R.UserId
                }).ToList()

                }).ToList()

            };

            return video;
        }

        // PUT: api/Videos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVideo(int id, Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != video.Video_id)
            {
                return BadRequest();
            }

            db.Entry(video).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VideoExists(id))
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

        
        // DELETE: api/Videos/5
        [ResponseType(typeof(Video))]
        public async Task<IHttpActionResult> DeleteVideo(int id)
        {
            Video video = await db.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            db.Videos.Remove(video);
            await db.SaveChangesAsync();

            return Ok(video);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VideoExists(int id)
        {
            return db.Videos.Count(e => e.Video_id == id) > 0;
        }
    }
}