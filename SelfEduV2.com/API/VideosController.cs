using System;
using System.Collections.Generic;
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

namespace SelfEduV2.com.API
{
    public class VideosController : ApiController
    {
        private SelfEduContext db = new SelfEduContext();

        // GET: api/Videos
        public IQueryable<Video> GetVideos()
        {
            return db.Videos;
        }

        // GET: api/Videos/5
        [ResponseType(typeof(Video))]
        public async Task<IHttpActionResult> GetVideo(int id)
        {
            Video video = await db.Videos.FindAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            return Ok(video);
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

        // POST: api/Videos
        [HttpPost]
        public async Task<IHttpActionResult> PostVideo(FormDataCollection coll)
        {
            //Request.Files[0] as HttpPostedFileBase;
            //var httpRequest = HttpContext.Current.Request.

            //string s = HttpContext.Current.Request.Params.Get("title");
            
            string b = coll.Get("title");
            string s = HttpContext.Current.Request.Form["title"];
            /*
            //MUST redo as I am using a formData not the model
            var user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
            var chanId = user.ChannelId;

            if (user.Id != null && chanId > 0)
            {
                Video videoM = new Video();
                videoM.Title = title;
                videoM.Description = description;
                videoM.Keywords = keywords;
                videoM.ChannelId = chanId;
                videoM.FilePath = "";//need to create the file path
                var thumbnailImg = thumbnail;
                var videoImg = video;

                if (!ModelState.IsValid)
                {
                    return Json(new { message = "failed"});
                    //return CreatedAtRoute("message", new { me = ""}, Json);
                }

                db.Videos.Add(videoM);
                await db.SaveChangesAsync();
                return Json(new { message = "worked" });
                //return CreatedAtRoute("DefaultApi", new { id = videoM.Video_id }, videoM);
            }*/
            return Json(new { message = s });
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