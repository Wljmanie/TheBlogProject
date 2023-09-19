using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheBlogProject.Models
{
    public class BlogUser : IdentityUser
    {
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [StringLength(30, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 2)]
        [Display(Name = "Display Name")]
        public string DisplayName { get; set; }

        [Display(Name = "User Image")]
        public byte[]? ImageData { get; set; }
        [Display(Name = "Image Type")]
        public string? ImageType { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

        public string? TwitterUrl { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        //Navigation Properties
        public virtual ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
        
    }
}
