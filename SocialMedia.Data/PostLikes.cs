using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class PostLikes
    {
        [Key]
        public int PostId { get; set; }

        public int AuthorId { get; set; }

        public int Like { get; set; }

        public virtual ICollection<Post> ListOfPosts { get; set; }
        public PostLikes()
        {
            ListOfPosts = new HashSet<Post>();
        }
    }
}