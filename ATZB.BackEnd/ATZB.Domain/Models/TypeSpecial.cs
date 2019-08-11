using System;
using System.Collections.Generic;
using System.Text;

namespace ATZB.Domain.Models
{
    public class TypeSpecial
    {
        public TypeSpecial(TypeOfSpecial typeOfSpecial)
        {
            this.Id = Guid.NewGuid().ToString();
            TypeOfSpecial = typeOfSpecial;
        }

        public string Id { get; set; }

        public TypeOfSpecial TypeOfSpecial { get; set; }

        
    }
}
