using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Domain.Models;

namespace ATZB.Web.ViewModels.UserTypeRegisters
{
    public class ClientCompanyBindingModel
    {
        [Required]
        [StringLength(20 , MinimumLength = 3)]
        public string CompanyName { get; set; }

        [Required]
        public string Adress { get; set; }

        [Required]
        public string ENK { get; set; }

        [Required]
        public string DDSNum { get; set; }

        [Required]
        public string REGKSB { get; set; }

        [Required]
        public string Mol { get; set; }

        [Required]
        public Cities City { get; set; }

        [Required]
        public bool AnyObligations { get; set; }

        [Required]
        [StringLength(20 , MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}
