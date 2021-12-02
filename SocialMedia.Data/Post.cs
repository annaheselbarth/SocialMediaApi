using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }



        public virtual ICollection<PostComments> ListOfComments { get; set; }

        public virtual ICollection<PostLikes> ListOfPostLikes { get; set; }

        public Post()
        {
            ListOfComments = new HashSet<PostComments>();
            ListOfPostLikes = new HashSet<PostLikes>();
        }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
