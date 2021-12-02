using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Models
{
    public class ReplyEdit
    {
        [Display(Name = "Reply ID")]
        public int ReplyID { get; set; }
        [Display(Name = "Reply")]
        public string Text { get; set; }
    }
}
