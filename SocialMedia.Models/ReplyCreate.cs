using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyCreate
    {
        public int ReplyID { get; set; }
        [MaxLength(200, ErrorMessage = "Comment is too long (Max 200).")]
        public string Text { get; set; }
        //public int CommentID { get; set; }
        //public virtual Comment Comment { get; set; }
    }
}
