using System;

namespace ATZB.Domain
{
    public class TypeOfOrder
    {
        public TypeOfOrder()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
    }
}