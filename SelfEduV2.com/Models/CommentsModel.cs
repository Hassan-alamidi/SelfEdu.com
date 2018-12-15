using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models
{
    public class UserComments
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        //like to dislike rating is slightly different than video and article rating
        //if someone presses like then rating++ else if someone dislike rating--
        //it is done in this mannor because we do not need a deep level of granularity
        public int Rating { get; set; }
        private ICollection<UserComments> _Replies;
        //NOTE might change this to ApplicationUser if I make a user profile page
        private int _userId;

        public int UserId
        {
            get { return _userId; }
            set
            {
                if (_userId > 0) {
                    _userId = value;
                }
            }
        }

        public UserComments()
        {
            _Replies = new List<UserComments>();
        }

        public virtual ICollection<UserComments> Replies
        {
            get { return _Replies; }
            set { _Replies = value; }
        }
    }
}