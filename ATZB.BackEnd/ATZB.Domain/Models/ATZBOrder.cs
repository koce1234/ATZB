using System;
using System.Collections.Generic;
using System.Text;

namespace ATZB.Domain
{
    //TODO: TRQBWA DA DOBAWQ SNIMKI I FAILOVE(EVENTUALNO)
    //s
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

        public TypeOfOrder Type { get; set; }

        public ATZBUserOrder User { get; set; }

        public string UserId { get; set; }
    }
}
