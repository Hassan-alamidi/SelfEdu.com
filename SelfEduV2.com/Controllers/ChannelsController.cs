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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SelfEduV2.com.Controllers
{
    [RoutePrefix("Channels")]
    public class ChannelsController : Controller
    {
        private SelfEduContext db = SelfEduContext.Create();
        //private ApplicationDbContext AppDb = new ApplicationDbContext();

        // GET: Channels
        public async Task<ActionResult> Index()
        {
            return View(await db.Channels.ToListAsync());
        }

        // POST: Channels/Details/5
        [HttpPost]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channel channel = await db.Channels.FindAsync(id);
            if (channel == null)
            {
                return HttpNotFound();
            }
            return View(channel);
        }

        // GET: Channels/Details
        //GET: /Channels/Details?isMyChan=false&chanId=19
        [HttpGet]
        public async Task<ActionResult> Details(bool isMyChan, int chanId)
        {
            int id;
            if (isMyChan)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
                id = user.UserChannel.Channel_id;
            }
            else
            {
                id = chanId;
            }
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channel channel = await db.Channels.FindAsync(id);
            if (channel == null)
            {
                return HttpNotFound();
            }
            return View(channel);
        }

        // GET: Channels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Channels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RegisterAsACreatorViewModel model)
        {
           
            if (ModelState.IsValid)
            {
                ApplicationUser user = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>().FindById(User.Identity.GetUserId());
                if (user.UserChannel == null)
                {
                    Channel channel = new Channel();
                    channel.ChannelName = model.ChannelName;
                    channel.Keywords = model.keywords;

                    //db.Channels.Add(channel);
                    //var result = await db.SaveChangesAsync();

                    //if (result > 0 && channel.Channel_id > 0)
                    //{
                        // Create an instance of the UserManager
                        ApplicationUserManager mngr = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
                        // Get a handle on an ApplicationUser
                        // Update user directly here


                        //AccountController controller = new AccountController();
                        if (user.Id != "0" && user.Id != null)
                        {
                            user.UserChannel = channel;
                            user.FirstName = model.FirstName;
                            user.SecondName = model.SecondName;
                            user.Country = model.Country;
                            user.HomeAddress = model.HomeAddress;
                            if (model.PaymentMethod != null && model.PaymentMethod != "")
                            {
                                user.PaymentMethod = model.PaymentMethod;
                            }
                        }

                        var result2 = await mngr.UpdateAsync(user);
                        //var success = await controller.BecomeACreator(model, channel.Channel_id, user);
                        //var success = await UserManager.Update(user);
                        await db.SaveChangesAsync();
                         if (result2.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            //if fails then remove channel
                            db.Channels.Remove(channel);
                            await db.SaveChangesAsync();
                        }
                    //}
                    return RedirectToAction("About", "Home");
                }
                //this should redirect to channel and should be done in the cshtml but need to figure out how first
                return RedirectToAction("About", "Home");
            }
            return RedirectToAction("About", "Home");
           
        }

        // GET: Channels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Channel channel = await db.Channels.FindAsync(id);
            if (channel == null)
            {
                return HttpNotFound();
            }
            return View(channel);
        }

        // POST: Channels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Channel_id,ChannelName,SubscriberCount,Keywords")] Channel channel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(channel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(channel);
        }

        // GET: Channels/Delete/5
        public async Task<ActionResult> Delete()
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            int id = user.UserChannel.Channel_id;
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Channel channel = await db.Channels.FindAsync(id);
            if (channel == null)
            {
                return HttpNotFound();
            }
            return View(channel);
        }

        // POST: Channels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed()
        {
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            int id = user.UserChannel.Channel_id;
            Channel channel = await db.Channels.FindAsync(id);
            channel.VideoCollection.Clear();
            channel.Subscribers.Clear();
            db.Channels.Remove(channel);
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
