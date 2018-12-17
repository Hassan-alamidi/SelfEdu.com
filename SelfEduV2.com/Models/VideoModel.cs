using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models
{
    public class Video
    {
        [Key]
        public int Video_id { get; set; }
        [Required]
        //[Index(IsUnique = true)]
        [StringLength(850)]
        public string FilePath { get; set; }
        [Required]
        //[Index(IsUnique = true)]
        [StringLength(850)]
        public string ThumbnailPath { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [StringLength(130)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Keywords { get; set; }
        [Required]
        private Channel _CreatorChannel;
        public int Views { get; set; }
        public int OverAllRating { get; set; }
        public DateTime Date { get; set; }
        private ICollection<Rating> _Ratings;
        private ICollection<UserComments> _Comments;

        public Video()
        {
            Date = DateTime.Now;
            _Comments = new List<UserComments>();
            _Ratings = new List<Rating>();
        }

        public virtual Channel CreatorChannel {
            get { return _CreatorChannel; }
            set { _CreatorChannel = value; }
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