using System;
using System.Collections.Generic;
using System.Text;

namespace ATZB.Domain.Models
{

    public class ATZBOffert
    {
        public ATZBOffert()
        {
            Id = Guid.NewGuid().ToString();
            
        }
        public string Id { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }

        public ATZBUser User { get; set; }

        public TypeOfSpecial TypeForOfferts { get; set; }

        public Cities City { get; set; }
    }
}
