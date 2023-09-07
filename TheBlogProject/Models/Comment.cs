using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using TheBlogProject.Enums;

namespace TheBlogProject.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string AuthorId { get; set; }
        public string? ModeratorId { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 3)]
        public string Body { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Updated { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Moderated { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Deleted { get; set; }

        public string? ModeratedBody { get; set; }
        public ModerationType ModerationType { get; set; }

        //Navigation Properties
        public virtual Post Post { get; set; }
        public virtual IdentityUser? Author { get; set; }
        public virtual IdentityUser? Moderator { get; set; }
    }
}
