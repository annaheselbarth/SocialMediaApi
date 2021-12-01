using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class PostComments
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual ICollection<Post> ListOfPosts { get; set; }

        public PostComments()
        {
            ListOfPosts = new HashSet<Post>();
        }
    }
}
