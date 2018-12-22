using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models
{
    public class SelfEduContext : IdentityDbContext<ApplicationUser>
    {
        public SelfEduContext() : base("SelfEduContext", throwIfV1Schema:false)
        {

        }

        public static SelfEduContext Create()
        {
            return new SelfEduContext();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Rating> UserRatings { get; set; }
        public DbSet<UserComments> UserComments { get; set; }

    }
}