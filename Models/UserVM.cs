using System.ComponentModel.DataAnnotations;

namespace VCodify.Models
{
        public class UserVM
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Salt { get; set; }
            public int? RoleId { get; set; }
            public bool? IsDeleted { get; set; }
            public DateTime? CreatedDate { get; set; }
            public DateTime? ModifiedDate { get; set; }
        }
        public class LoginVM
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Salt { get; set; }
            public string UserName { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
            public bool EmailVerified { get; set; }
            public string AuthToken { get; set; }
            public int UserType { get; set; }
            public int Status { get; set; }
            public bool RememberMe { get; set; }



        }
    }

