using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace TheBlogProject.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 3)]
        public string Text { get; set; }

        public virtual BlogUser? Author { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; } = new HashSet<PostTag>();
    }
}
