using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VCodify.Models
{
    public class EnquiryVM
    {
        [Required(ErrorMessage = "ID is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(150, ErrorMessage = "Email cannot exceed 150 characters.")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } // Optional but must be valid if provided

        [Required(ErrorMessage = "Project is required.")]
        [StringLength(200, ErrorMessage = "Project name cannot exceed 200 characters.")]
        [Display(Name = "Project Name")]
        public string Project { get; set; }

        [Required(ErrorMessage = "Message is required.")]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters.")]
        [Display(Name = "Your Message")]
        public string Message { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public List<EnquiryVM> EnquiryList { get; set; } = new List<EnquiryVM>();
    }


}
