using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models
{
    public class UploadVideoViewModel
    {
        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Keywords Seperate By (,)")]
        public string Keywords { get; set; }

        [Required]
        [Display(Name ="Video thumbnail")]
        public HttpPostedFileBase Thumbnail { get; set; }

        [Required]
        [Display(Name = "Video")]
        public HttpPostedFileBase Video { get; set; }

    }
}