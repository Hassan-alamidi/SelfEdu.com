using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models
{
    public class Channel
    {

        [Key]
        public int Channel_id { get; set; }
        [Required]
        [Index(IsUnique = true)]
        [StringLength(150)]
        public string ChannelName { get; set; }
        public int SubscriberCount { get; set; }
        [Required]
        public string Keywords { get; set; }
        private ICollection<Video> _VideoCollection;
        private ICollection<Article> _ArticleCollection;
        //not sure if I should store users in this manner
        private ICollection<ApplicationUser> _Subscribers;

        public Channel()
        {
            _Subscribers = new List<ApplicationUser>();
            _VideoCollection = new List<Video>();
            _ArticleCollection = new List<Article>();
        }

        public virtual ICollection<ApplicationUser> Subscribers {
            get { return _Subscribers; }
            set {
                    _Subscribers = value;
                    SubscriberCount = _Subscribers.Count;
                }
            
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