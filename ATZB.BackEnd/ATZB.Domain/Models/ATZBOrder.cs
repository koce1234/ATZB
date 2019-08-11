using System;
using System.Collections.Generic;
using System.Text;
using ATZB.Domain.Models;

namespace ATZB.Domain
{
    public class ATZBOrder
    {
        public ATZBOrder()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Description { get; set; }

        public decimal PriceTo { get; set; }

        public string Town { get; set; }

        public TypeOfSpecial TypeForOrder { get; set; }
        public ATZBUser User { get; set; }

        public string UserId { get; set; }
    }
}
