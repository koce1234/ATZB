using System;
using System.Collections.Generic;
using ATZB.Domain.Models;

namespace ATZB.Domain
{
    public class ATZBUser
    {
        public ATZBUser()
        {
            this.Id = Guid.NewGuid().ToString();

            this.Orders = new HashSet<ATZBOrder>();

            this.Offers = new HashSet<ATZBOffert>();

            this.ImagesLinks = new HashSet<Image>();

            this.TypeOfSpecials = new HashSet<TypeSpecial>();
        }

        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string EGN { get; set; }

        public string LKNummber { get; set; }

        public string Phone { get; set; }

        public string ENK { get; set; }

        public string DDSNumber { get; set; }

        public string Mol { get; set; }

        public string RegKSB { get; set; }

        public bool AnyObligations { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }


        public UserType UserType { get; set; }

        public Cities City { get; set; }

        public ICollection<TypeSpecial> TypeOfSpecials { get; set; }


        public ICollection<Image> ImagesLinks { get; set; }

        public ICollection<ATZBOffert> Offers { get; set; }

        public ICollection<ATZBOrder> Orders { get; set; }
    }
}
