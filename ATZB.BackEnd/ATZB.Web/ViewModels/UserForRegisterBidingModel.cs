namespace ATZB.Web.Controllers.Dto_s
{
    using System.ComponentModel.DataAnnotations;

    public class UserForRegisterBidingModel
    {
        [Required]
        [StringLength(15, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 6)]
        public string StreetAddress { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 4)]
        public string City { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string EGN { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string LKNumber { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        public string ENK { get; set; }

        public string DDSNumber { get; set; }

        public string RegKSB { get; set; }

        public bool AnyObligations { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
