using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SelfEdu.com.Models
{
    public class SelfEduContext : DbContext
    {
        public SelfEduContext() : base("SelfEduContext")
        {

        }

        public static SelfEduContext Create()
        {
            return new SelfEduContext();
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<Rating> UserRatings { get; set; }
        public DbSet<UserComments> UserComments { get; set; }
    }
}