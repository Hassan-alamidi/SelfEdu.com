using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models
{
    public class RegisterAsACreatorViewModel
    {
        //details like the users real name are only really needed when money is involed 
        //hence the reason it is not asked for until now
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Second Name")]
        public string SecondName { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Required]
        [Display(Name = "Channel Name")]
        [StringLength(40, ErrorMessage = "Channel Name is limited to 40 letters and/or numbers", MinimumLength = 4)]
        public string ChannelName { get; set; }

        [Required]
        [Display(Name = "Profile Keywords, should be seperated by (,)")]
        public string keywords { get; set; }

        [Display(Name = "Payment Method: how would you like to be paid?")]
        public string PaymentMethod { get; set; }
    }


}