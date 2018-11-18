using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEdu.com.Models
{
    public class Video
    {
        [Key]
        public int Video_id { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public int ChannelId { get; set; }
        public int Views { get; set; }
        private ICollection<Rating> _Ratings;
        private ICollection<UserComments> _Comments;

        public Video()
        {
            _Comments = new List<UserComments>();
            _Ratings = new List<Rating>();
        }

        public virtual ICollection<Rating> Ratings
        {
            get { return _Ratings; }
            set { _Ratings = value; }
        }
        public virtual ICollection<UserComments> Comments
        {
            get { return _Comments; }
            set { _Comments = value; }
        }
    }
}