using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models.DTOs
{
    public class VideoDTO
    {
        //all items contained within this DTO should be all we need from a search
        //video details
        public int Video_id { get; set; }
        public string Title { get; set; }
        public string Keywords { get; set; }
        public string Description { get; set; }
        public int Views { get; set; }
        public DateTime Date { get; set; }
        //video rating
        public int OverAllRating{ get; set;}
        public List<Rating> Ratings { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        //this lets the page know if the user has already rated this page
        public string CurrentUserRating { get; set; }
        //video comments
        public List<CommentDTO> Comments { get; set; }
        //this will be used to get some of the users other videos for display purposes
        public List<VideoDTO> Videos { get; set; } 
        //channel details
        //need a better way of setting this up
        //find way to store identity into this
        public int ChannelId { get; set; }
        public ChannelDTO CreatorChannel { get; set; }
        public string ChannelName { get; set; }
        
        public string FilePath { get; set; }
        public string ThumbnailPath { get; set; }


    }
}