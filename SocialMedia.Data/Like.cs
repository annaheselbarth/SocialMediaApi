using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Like
    {
        [Key]
        public int PostId { get; set; }
        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }
        public int LikeId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}
