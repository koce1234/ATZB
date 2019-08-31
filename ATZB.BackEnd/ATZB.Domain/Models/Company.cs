namespace ATZB.Domain.Models
{
    using System;

    public class Company
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public bool AnyObligation { get; set; }

        public int DirectorPrsonalDocumentNumber { get; set; }

        public string ENK { get; set; }

        public string DDSNumber { get; set; }

        public string Mol { get; set; }

        public string RegKSB { get; set; }

        public string UserId { get; set; }

        public ATZBUser User { get; set; }
    }
}
