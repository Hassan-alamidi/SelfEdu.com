using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEdu.com.Models
{
    public class Article
    {
        [Key]
        public int Article_id { get; set; }
        public string FilePath { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Keywords { get; set; }
        public int ChannelId { get; set; }
        public int Views { get; set; }
        private ICollection<UserComments> _Comments;
        private ICollection<Rating> _Ratings;

        public Article()
        {
            _Ratings = new List<Rating>();
            _Comments = new List<UserComments>();
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