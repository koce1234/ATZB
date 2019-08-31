namespace ATZB.Domain
{
    using System;
    using System.Collections.Generic;
    using ATZB.Domain.Models;

    public class ATZBUser
    {
        public ATZBUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Orders = new HashSet<ATZBOrder>();

            this.Offers = new HashSet<ATZBOffert>();

            this.ImagesLinks = new HashSet<Image>();
        }

        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string StreetAdress { get; set; }

        public string EGN { get; set; }

        public string Phone { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }

        public string CompanyId { get; set; }

        public Company Company { get; set; }

        public Cities City { get; set; }

        public ICollection<Image> ImagesLinks { get; set; }

        public ICollection<ATZBOffert> Offers { get; set; }

        public ICollection<ATZBOrder> Orders { get; set; }
    }
}
