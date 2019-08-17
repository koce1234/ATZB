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
        public string Town { get; set; }

        [Required]
        public TypeOfSpecial TypeOfOrder { get; set; }
    }
}
