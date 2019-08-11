using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Domain;
using ATZB.Domain.Models;

    public class AddOrderBindingModel
    {
        public string Description { get; set; }

        public decimal PriceTo { get; set; }

        public string Town { get; set; }

        public TypeOfSpecial TypeOfOrder { get; set; }
    }
}
