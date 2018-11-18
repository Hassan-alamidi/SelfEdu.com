using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEdu.com.Models
{
    public class Channel
    {

        [Key]
        public int Channel_id { get; set; }
        public string ChannelName { get; set; }
        public int SubscriberCount { get; set; }
        public string Keywords { get; set; }
        private ICollection<Video> _VideoCollection;
        private ICollection<Article> _ArticleCollection;
        //not sure if I should store users in this manner
        //private ICollection<ApplicationUser> _Subscribers;

        public Channel()
        {
            _VideoCollection = new List<Video>();
            _ArticleCollection = new List<Article>();
        }

        public virtual ICollection<Article> ArticleCollection
        {
            get { return _ArticleCollection; }
            set { _ArticleCollection = value; }
        }

        public virtual ICollection<Video> VideoCollection
        {
            get { return _VideoCollection; }
            set { _VideoCollection = value; }
        }

    }
}