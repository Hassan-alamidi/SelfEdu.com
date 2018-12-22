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

namespace SelfEduV2.com.API
{
    [RoutePrefix("api/Ratings")]
    public class RatingsController : ApiController
    {
        private SelfEduContext db = new SelfEduContext();

        // GET: api/Ratings
        public IQueryable<Rating> GetUserRatings()
        {
            return db.UserRatings;
        }

        // GET: api/Ratings/5
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> GetRating(int id)
        {
            Rating rating = await db.UserRatings.FindAsync(id);
            if (rating == null)
            {
                return NotFound();
            }

            return Ok(rating);
        }

        // PUT: api/Ratings/5
        [HttpPut]
        [Route("Update/{id}")]
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRating([FromUri] int id)
        {
            Video video = db.Videos.Find(id);
            string userId = User.Identity.GetUserId();
            Rating rating = video.Ratings.Where(R => R.User_id == userId).FirstOrDefault<Rating>();
            if (video == null || rating == null)
            {
                return NotFound();
            }
            //if this method was called at all then there is only one action to be performed
            //which is change islike to opposite of previous value
            rating.IsLike = rating.IsLike == true ? false : true;
            //db.Entry(rating).State = EntityState.Modified;
            
            try
            {

                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingExists(id))
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

        // POST: api/Ratings
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> PostRating([FromBody] Rating rating)
        {
            rating.User_id = User.Identity.GetUserId();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string userId = User.Identity.GetUserId();
            Video vid = db.Videos.Find(rating.Content_id);
            
            vid.Ratings.Add(rating);
            await db.SaveChangesAsync();
            return Ok("success");
        }

        // DELETE: api/Ratings/5
        [HttpDelete]
        [Route("Delete/{id}")]
        [ResponseType(typeof(Rating))]
        public async Task<IHttpActionResult> DeleteRating(int id)
        {
            Video video = db.Videos.Find(id);
            string userId = User.Identity.GetUserId();
            Rating rating = video.Ratings.Where(R => R.User_id == userId).FirstOrDefault<Rating>();
            if (video == null || rating == null)
            {
                return NotFound();
            }
            db.UserRatings.Remove(rating);
            //video.Ratings.Remove(rating);
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

        private bool RatingExists(int id)
        {
            return db.UserRatings.Count(e => e.Rating_id == id) > 0;
        }
    }
}