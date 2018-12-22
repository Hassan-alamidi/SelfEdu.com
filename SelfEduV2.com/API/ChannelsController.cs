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
    [RoutePrefix("api/Channels")]
    public class ChannelsController : ApiController
    {
        private SelfEduContext db = new SelfEduContext();

        // GET: api/Channels
        public IQueryable<Channel> GetChannels()
        {
            return db.Channels;
        }

        // GET: api/Channels/5
        [HttpGet]
        [ResponseType(typeof(ChannelDTO))]
        public async Task<IHttpActionResult> GetChannel(int id)
        {
            Channel channel = await db.Channels.FindAsync(id);
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            bool isSub = channel.Subscribers.Contains(user);//.FirstOrDefault<string>(S=>S == userId);
            ChannelDTO chan = new ChannelDTO
            {
                Id = channel.Channel_id,
                ChannelName = channel.ChannelName,
                SubscriberCount = channel.SubscriberCount,
                Subscribers = channel.Subscribers.Select(S => new UserDTOcs() {
                    Id = S.Id,
                    Username = S.UserName
                }).ToList(),
                IsCurrentUserSub = isSub
            };
            if (channel == null)
            {
                return NotFound();
            }

            return Ok(chan);
        }

        // PUT: api/Channels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutChannel(int id, Channel channel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != channel.Channel_id)
            {
                return BadRequest();
            }

            db.Entry(channel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChannelExists(id))
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

        // POST: api/Channels/Subscribe
        [HttpPost]
        [Route("Subscribe")]
        [ResponseType(typeof(Channel))]
        public async Task<IHttpActionResult> PostSubscription([FromBody] Channel channel)
        {
            
            Channel chan = await db.Channels.FindAsync(channel.Channel_id);
            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            if (chan == null || user.UserChannel.Channel_id == chan.Channel_id) {
                return NotFound();
            }

            
            user.Subscriptions.Add(chan);
            chan.Subscribers.Add(user);
            chan.SubscriberCount += 1;
            await db.SaveChangesAsync();

            return Ok("success");
        }

        // DELETE: api/Channels/5
        [HttpDelete]
        [Route("Unsubscribe/{id}")]
        [ResponseType(typeof(Channel))]
        public async Task<IHttpActionResult> DeleteSubscription([FromUri] int id)
        {

            ApplicationUser user = db.Users.Find(User.Identity.GetUserId());
            Channel chan = await db.Channels.FindAsync(id);

            if (chan == null || user.UserChannel.Channel_id == chan.Channel_id)
            {
                return NotFound();
            }

            user.Subscriptions.Remove(chan);
            chan.Subscribers.Remove(user);
            chan.SubscriberCount -= 1;
            await db.SaveChangesAsync();

            return Ok("success");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChannelExists(int id)
        {
            return db.Channels.Count(e => e.Channel_id == id) > 0;
        }
    }
}