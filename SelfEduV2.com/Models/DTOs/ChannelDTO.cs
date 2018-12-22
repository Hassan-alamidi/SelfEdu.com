using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models.DTOs
{
    public class ChannelDTO
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int SubscriberCount { get; set; }
        public List<VideoDTO> VideoCollection { get; set; }
        public List<UserDTOcs> Subscribers { get; set; }
        public bool IsCurrentUserSub { get; set; }
    }
}