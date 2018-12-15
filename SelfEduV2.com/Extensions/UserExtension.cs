using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace SelfEduV2.com.Extensions
{
    public static class UserExtension
    {

        public static bool HasChannel(this IIdentity identity) {
            //I do not want to allow client side to have access to actual ids so instead I will return a bool, true if greater than 0 false if less than or equal to
            var chanId = ((ClaimsIdentity)identity).FindFirst("ChannelId");
            if (chanId != null) {
                int Id = Int32.Parse(chanId.Value);
                return Id > 0 ? true : false;
            }
            return false;
        }
    }
}