﻿using System;
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
        public string Date { get; set; }
        //NOTE if things go wrong check to see if issue is due to storage of its own model within its self
        public List<CommentDTO> Replies { get; set; }
        
        public string UserName { get; set; }
        //reference to video Id
        public int Video_id { get; set; }

    }
}