using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Data
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        [Required]
        public string Text { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostID { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Reply> ListOfReplies { get; set; }

        public Comment()
        {
            ListOfReplies = new HashSet<Reply>();
            
        }


    }
}
