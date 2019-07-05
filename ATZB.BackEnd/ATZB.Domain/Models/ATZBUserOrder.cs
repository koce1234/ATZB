using System;
using System.Collections.Generic;
using System.Text;

namespace ATZB.Domain
{
    public class ATZBUserOrder
    {
        public string UserId { get; set; }

        public ATZBUser User { get; set; }

        public string OrderId { get; set; }

        public ATZBOrder Order { get; set; }
    }
}
