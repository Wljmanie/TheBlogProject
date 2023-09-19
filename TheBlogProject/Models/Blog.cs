﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheBlogProject.Enums;

namespace TheBlogProject.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? AuthorId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} and at most {1} characters.", MinimumLength = 3)]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        public ProductionStatus ProductionStatus { get; set; }

        [Display(Name = "Blog Image")]
        public byte[]? ImageData { get; set; }
        [Display(Name = "Image Type")]
        public string? ImageType { get; set; }

        [NotMapped]
        public IFormFile? Image {  get; set; }

        //Navigation Properties
        public virtual BlogUser? Author { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();    
    }
}
