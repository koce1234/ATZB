using System;
using System.Collections.Generic;
using System.Text;

namespace ATZB.Domain
{
    //TODO: KOL.SMETKA
    public class ATZBOffert
    {
        public ATZBOffert()
        {
            this.Id = Guid.NewGuid().ToString();

        }
        public string Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public ATZBUser User { get; set; }
    }
}
