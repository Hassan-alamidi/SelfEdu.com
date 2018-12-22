using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using SelfEduV2.com.Models;
using SelfEduV2.com.Models.DTOs;

namespace SelfEduV2.com.API
{
    public class ApplicationUsersController : ApiController
    {
        private SelfEduContext db = new SelfEduContext();

        // GET: api/ApplicationUsers/5
        [ResponseType(typeof(UserDTOcs))]
        public IHttpActionResult GetApplicationUser()
        {
            ApplicationUser applicationUser = db.Users.Find(User.Identity.GetUserId());
            if (applicationUser == null)
            {
                return NotFound();
            }

            UserDTOcs user = new UserDTOcs {
                Id = applicationUser.Id,
                Subscriptions = applicationUser.Subscriptions.Select(Sub => new ChannelDTO() {
                    ChannelName = Sub.ChannelName,
                    Id = Sub.Channel_id
                }).ToList()
            };

            return Ok(user);
        }

        // PUT: api/ApplicationUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutApplicationUser(string id, ApplicationUser applicationUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != applicationUser.Id)
            {
                return BadRequest();
            }

            db.Entry(applicationUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationUserExists(id))
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

        // DELETE: api/ApplicationUsers/5
        [ResponseType(typeof(ApplicationUser))]
        public async Task<IHttpActionResult> DeleteApplicationUser(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            db.Users.Remove(applicationUser);
            await db.SaveChangesAsync();

            return Ok(applicationUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ApplicationUserExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}