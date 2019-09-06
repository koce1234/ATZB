using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ATZB.Domain.Models
{
    public class AddOrderBindingModel
    {
       
        [Required]
        public string Description { get; set; }

        [Required]
        public decimal PriceTo { get; set; }

        [Required]
        public Cities City { get; set; }

        [Required]
        public TypeOfSpecial TypesOfOrder { get; set; }
    }
}
