using System;
using System.Collections.Generic;
namespace ATZB.Domain.Models
{
    public class AddOrderBindingModel
    {
        public string Description { get; set; }

        public decimal PriceTo { get; set; }

        public string Town { get; set; }

        public TypeOfSpecial TypeOfOrder { get; set; }
    }
}
