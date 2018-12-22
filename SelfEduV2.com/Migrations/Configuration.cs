namespace SelfEduV2.com.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SelfEduV2.com.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SelfEduV2.com.Models.SelfEduContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SelfEduV2.com.Models.SelfEduContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            var userManager = new ApplicationUserManager(new UserStore<Models.ApplicationUser>(context));

            var comments = new List<UserComments>
            {
                new UserComments{Comment="nice video",Date=DateTime.Now},
                new UserComments{Comment="great video",Date=DateTime.Now},
                new UserComments{Comment="poor video",Date=DateTime.Now},
                 new UserComments{Comment="thanks",Date=DateTime.Now},
                new UserComments{Comment="dumb",Date=DateTime.Now},
                new UserComments{Comment="cool",Date=DateTime.Now}
            };
            comments.ForEach(C => context.UserComments.AddOrUpdate(com => com.Comment, C));
            context.SaveChanges();
            
            var videos = new List<Video>
            {
                //links to pre-exsiting files
                new Video{FilePath="/userContent/22/videos/1 - Introduction.mp4", ThumbnailPath="/userContent/22/videos/thumbnails/color-palette-picker.jpg", Title="howtoAsp", Description="any random string",
                Date = DateTime.Now,Keywords="noteven,sure",  Comments = comments.Where(C=>(C.Comment == "nice video" || C.Comment == "great video" || C.Comment == "dumb")).ToList()},
                new Video{FilePath="/userContent/22/videos/1 - Introduction.mp4", ThumbnailPath="/userContent/22/videos/thumbnails/color-palette-picker.jpg", Title="howNotToAsp", Description="whyyyyy",
                Date = DateTime.Now,Keywords="noteven,sure", Comments = comments.Where(C=>(C.Comment == "cool" || C.Comment == "thanks" || C.Comment == "dumb")).ToList()}
            };
            videos.ForEach(V => context.Videos.AddOrUpdate(Vid => Vid.Title, V));
            context.SaveChanges();

            var user = new ApplicationUser
            {
                UserName = "HA",
                FirstName = "Hassan",
                SecondName = "AlAmidi",
                Country = "Ireland",
                HomeAddress = "123 Easy Street",
                DateOfBirth = DateTime.Now
                
                
            };

            var user2 = new ApplicationUser
            {
                UserName = "bA",
                FirstName = "john",
                SecondName = "doe",
                Country = "Ireland",
                HomeAddress = "12 Easy Street",
                DateOfBirth = DateTime.Now,
                CommentsMade = comments.ToList()
            };

            Channel channel = new Channel
            {
                ChannelName = "HassansChan",
                Keywords = "getting,Very,Tired",
                VideoCollection = videos.Where(V=>(V.Title == "howtoAsp" || V.Title == "howNotToAsp")).ToList()
            };

            user.UserChannel = channel;
            userManager.Create(user, "AnyPass!1");
            userManager.Create(user2, "AnyPass!1");
            context.SaveChanges();

            var rating = new List<Rating> {
                new Rating{IsLike=true, Content_id=videos.Where(V=>V.Title == "howtoAsp").Single().Video_id },
                new Rating{IsLike=false, Content_id=videos.Where(V=>V.Title == "howNotToAsp").Single().Video_id }
            };
            rating.ForEach(R => context.UserRatings.AddOrUpdate(Rate => Rate.IsLike, R));
            videos.Where(Vid => Vid.Title == "howtoAsp").Single().Ratings.Add(rating.Where(R => R.IsLike == true).Single());
            videos.Where(Vid => Vid.Title == "howNotToAsp").Single().Ratings.Add(rating.Where(R => R.IsLike == false).Single());
            context.SaveChanges();
        }
    }
}
