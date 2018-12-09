using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SelfEduV2.com.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string Country { get; set; }
        public string HomeAddress { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string PaymentMethod { get; set; }
        
        //payment details not sure how to handle this data as of yet so will implement later
        private int _ChannelId;
        private ICollection<Channel> _Subscriptions;
        private ICollection<UserComments> _CommentsMade;
        //rating has a reference to the user id so storing ratings in user may not be nessicary
        //private ICollection<Rating> _RatingsMade;

        public ApplicationUser()
        {
            _ChannelId = 0;
            _Subscriptions = new List<Channel>();
            _CommentsMade = new List<UserComments>();
        }

        public int ChannelId
        {
            get { return _ChannelId; }
            set
            {
                //the user can only have one channel so if the user already has a channel do not assign value
                if (_ChannelId == 0)
                {
                    _ChannelId = value;
                }
            }
        }

        public virtual ICollection<Channel> Subscriptions
        {
            get { return _Subscriptions; }
            set { _Subscriptions = value; }
        }
        
        public virtual ICollection<UserComments> CommentsMade
        {
            get { return _CommentsMade; }
            set { _CommentsMade = value; }
        }
                

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
           
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //public System.Data.Entity.DbSet<SelfEduV2.com.Models.Channel> Channels { get; set; }
    }
}