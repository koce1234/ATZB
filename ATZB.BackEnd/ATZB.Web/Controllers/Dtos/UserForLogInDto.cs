namespace ATZB.Web.Controllers.Dto_s
{
    using System.ComponentModel.DataAnnotations;

    public class UserForLogInDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
