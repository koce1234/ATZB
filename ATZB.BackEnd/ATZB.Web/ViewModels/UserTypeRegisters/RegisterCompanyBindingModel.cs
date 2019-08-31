namespace ATZB.Web.ViewModels.UserTypeRegisters
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterCompanyBindingModel
    {
        [Required]
        [StringLength(10, MinimumLength = 10)]
        public string DirectorPrsonalDocumentNumber { get; set; }

        [Required]
        public string ENK { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string DDSNumber { get; set; }

        [Required]
        public string Mol { get; set; }

        [Required]
        [StringLength(6, MinimumLength = 6)]
        public string RegKSB { get; set; }

        [Required]
        public bool AnyObligation { get; set; }
    }
}
