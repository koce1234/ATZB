namespace ATZB.Web.ViewModels.UserTypeRegisters
{
    using System.ComponentModel.DataAnnotations;
    using ATZB.Domain.Models;

    public class ClientRegisterdBindingModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public string StreetAdress { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string EGN { get; set; }

        [Required]
        public Cities City { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string ConfirmPassword { get; set; }
    }
}
