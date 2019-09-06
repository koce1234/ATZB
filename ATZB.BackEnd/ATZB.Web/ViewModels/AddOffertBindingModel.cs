using ATZB.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ATZB.Web.ViewModels
{
    public class AddOffertBindingModel
    {
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Cities City { get; set; }
        [Required]
        public TypeOfSpecial TypeOfOfferts { get; set; }
    }
}
