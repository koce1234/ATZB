using System;
using System.Collections.Generic;
using System.Text;

namespace ATZB.Domain.Models
{
    public class ATZBOrder
    {
        public ATZBOrder()
        {
            Id = Guid.NewGuid().ToString();
            
        }

        public string Id { get; set; }

        public string Description { get; set; }

        public decimal PriceTo { get; set; }

        public Cities Town { get; set; }

        public TypeOfSpecial TypeForOrders { get; set; }

        public ATZBUser User { get; set; }

        public string UserId { get; set; }
    }
}
