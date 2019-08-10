using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Domain;

namespace ATZB.Web.ViewModels
{
    public class AddOrderBindingModel
    {
        public string Description { get; set; }

        public decimal PriceTo { get; set; }

        public string Town { get; set; }

        public TypeOfOrder Type { get; set; }
    }
}
