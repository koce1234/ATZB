using System;
using System.Collections.Generic;
using System.Text;

namespace ATZB.Domain
{
    public class ATZBUserOffert
    {
        public string UserId { get; set; }

        public ATZBUser User { get; set; }

        public string OffertId { get; set; }

        public ATZBOffert Offert { get; set; }
    }
}
