using System.ComponentModel.DataAnnotations;
using ATZB.Domain.Models;

namespace ATZB.Web.ViewModels.UserTypeRegisters
{
    public class ClientRegisterdBindingModel
    {
        [Required]
        [StringLength(20 , MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string EGN { get; set; }

        [Required]
        public string LkNumber { get; set; }

        [Required]
        public bool AnyObligations { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public Cities City { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
