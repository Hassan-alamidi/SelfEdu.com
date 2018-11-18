using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEdu.com.Models
{
    public class RateViewModel
    {
        public bool IsLike { get; set; }
    }

    public class LeaveCommentViewModel
    {
        public string Comment { get; set; }
    }

    public class RateCommentViewModel
    {
        public bool IsLike { get; set; }
    }

    //used for uploading videos or submitting articles
    public class SubmitContentViewModel
    {

        //file path is set by script not user
        public string FilePath { get; set; }

        [Required]
        [Display(Name = "Video Title")]
        [StringLength(50, ErrorMessage = "title must be between 4 and 50 characters", MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Keywords")]
        public string Keywords { get; set; }

    }
}