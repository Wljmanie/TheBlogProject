using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheBlogProject.Enums;

namespace TheBlogProject.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string AuthorId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 3)]
        public string Abstract { get; set; }

        [Required]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        public ProductionStatus ProductionStatus { get; set; }
        public string Slug { get; set; }

        [Display(Name = "Post Image")]
        public byte[] ImageData { get; set; }
        [Display(Name = "Image Type")]
        public string ImageType { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }

        //Navigation Properties
        public virtual BlogUser Author { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<PostTag>? PostTags { get; set; } = new HashSet<PostTag>();
    }
}
