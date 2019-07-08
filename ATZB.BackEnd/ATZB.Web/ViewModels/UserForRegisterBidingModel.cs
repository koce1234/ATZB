namespace ATZB.Web.Controllers.Dto_s
{
    using System.ComponentModel.DataAnnotations;

    public class UserForRegisterBidingModel
    {
        [Required]
        [StringLength(30, MinimumLength = 7)]
        public string FullName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string Adress { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string EGN { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string LKNumber { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        public string ENK { get; set; }

        [Required]
        public string DDSNumber { get; set; }

        [Required]
        public string RegKSB { get; set; }

        [Required]
        public bool AnyObligations { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
