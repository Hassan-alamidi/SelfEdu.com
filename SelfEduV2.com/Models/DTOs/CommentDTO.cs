using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfEduV2.com.Models.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        //NOTE if things go wrong check to see if issue is due to storage of its own model within its self
        public List<CommentDTO> Replies { get; set; }
        //same as video controller need to figure out how to store user identity in this during 
        //creation
        public int UserId { get; set; }

    }
}