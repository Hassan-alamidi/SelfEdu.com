using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SelfEduV2.com.Models;
using System.IO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;


namespace SelfEduV2.com.Controllers
{
    public class VideosController : Controller
    {
        private SelfEduContext db = SelfEduContext.Create();
        private const string NetworkRoot = "C:/Users/haala/source/repos/SelfEduV2.com/SelfEduV2.com";
        private const string vFileLocation = "/userContent/{0}/videos/";
        private const string tFileLocation = "/userContent/{0}/videos/thumbnails/";
        // GET: Videos
        public async Task<ActionResult> Index()
        {
            return View(await db.Videos.ToListAsync());
        }

        // GET: Videos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = await db.Videos.FindAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            
            return View(video);
        }

        // GET: Videos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,Description,Keywords,Thumbnail,Video")] UploadVideoViewModel val)
        {

            
            if (ModelState.IsValid)
            {
                //ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
                ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
                if (user.Id != null)
                {
                    Channel channel = user.UserChannel;
                    int channelId = channel.Channel_id;
                    if (channelId > 0)
                    {
                        HttpPostedFileBase thumbnail = val.Thumbnail;
                        HttpPostedFileBase video = val.Video;

                        if (thumbnail.ContentType == "image/jpg" ||
                            thumbnail.ContentType == "image/jpeg" ||
                            thumbnail.ContentType == "image/png")
                        {
                            if (video.ContentType == "video/mp4" ||
                                video.ContentType == "video/x-ms-wmv" ||
                                video.ContentType == "video/mpeg" ||
                                video.ContentType == "video/x - msvideo")
                            {

                                
                                string thumbnailPath = string.Format(tFileLocation, channelId);
                                //create path if doesn't already exist
                                Directory.CreateDirectory(Server.MapPath(thumbnailPath));
                                thumbnailPath += thumbnail.FileName;
                                System.Diagnostics.Debug.WriteLine(Server.MapPath(thumbnailPath));
                                string videoPath = string.Format(vFileLocation, channelId) + video.FileName;
                                string rootVideoPath = System.Web.HttpContext.Current.Server.MapPath(videoPath);
                                string rootThumbnailPath = System.Web.HttpContext.Current.Server.MapPath(thumbnailPath);
                                //populate the video model with data

                                Video vid = new Video();
                                vid.Title = val.Title;
                                vid.Description = val.Description;
                                vid.Keywords = val.Keywords;
                                vid.FilePath = videoPath;
                                vid.ThumbnailPath = thumbnailPath;
                                vid.CreatorChannel = channel;
                                
                                db.Videos.Add(vid);
                                //the below seems to be uneeded as entity framework seems to be doing this for me
                                //Channel chan = db.Channels.First(c => c.Channel_id == channel.Channel_id);
                                //chan.VideoCollection.Add(vid);

                                await db.SaveChangesAsync();
                                
                                video.SaveAs(rootVideoPath);
                                thumbnail.SaveAs(rootThumbnailPath);
                                return RedirectToAction("Index");
                            }
                        }
                    }
                }
                return RedirectToAction("Create", "Channels");
            }
            return RedirectToAction("Login", "Account");
        }

        // GET: Videos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = await db.Videos.FindAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Video_id,FilePath,Title,Description,Keywords,ChannelId,Views")] Video video)
        {
            if (ModelState.IsValid)
            {
                db.Entry(video).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Video video = await db.Videos.FindAsync(id);
            if (video == null)
            {
                return HttpNotFound();
            }
            return View(video);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Video video = await db.Videos.FindAsync(id);
            db.Videos.Remove(video);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
