using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models
{
    public class Rating
    {
        [Key]
        public int Rating_id { get; set; }
        //if its not a like it is a dislike
        [Required]
        public bool IsLike { get; set; }
        [Required]
        public int Content_id { get; set; }
        [Required]
        public int User_id { get; set; }
    }
}