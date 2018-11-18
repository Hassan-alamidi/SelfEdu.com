using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEdu.com.Models
{
    public class UserComments
    {
        [Key]
        public int Id { get; set; }
        public string Comment { get; set; }
        //like to dislike rating is slightly different than video and article rating
        //if someone presses like then rating++ else if someone dislike rating--
        public int Rating { get; set; }
        private ICollection<UserComments> _Replies;

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