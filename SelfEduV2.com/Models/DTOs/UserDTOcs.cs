using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models.DTOs
{
    public class UserDTOcs
    {
        //dont really need any more information client side as the server
        //side will provide the rest when needed
        public string Id { get; set; }
        //not sure why I am getting this again as razor has access to this value
        public string Username { get; set; }
        public List<ChannelDTO> Subscriptions { get; set; }

    }
}