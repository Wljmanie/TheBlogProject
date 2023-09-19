using System.ComponentModel.DataAnnotations;

namespace TheBlogProject.ViewModels
{
    public class ContactMe
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 3)]
        public string Email { get; set; }
        public string Subject { get; set; }
        [Required]
        [StringLength(2500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 3)]
        public string Message { get; set; }
    }
}
