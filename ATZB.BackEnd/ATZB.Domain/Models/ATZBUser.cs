using System;
using System.Collections.Generic;

namespace ATZB.Domain
{
    //TODO: TRQBWA DA DOBAVQ KOLEKCII S SNIMKI I S FAILOVE
    public class ATZBUser 
    {
        public ATZBUser()
        {
            this.Id = Guid.NewGuid().ToString();
           
            this.Orders = new HashSet<ATZBUserOrder>();

            this.Offers = new HashSet<ATZBUserOffert>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Adress { get; set; }

        public string EGN { get; set; }

        public string LKNummber { get; set; }

        public string Phone { get; set; }

        public string ENK { get; set; }

        public string DDSNumber { get; set; }

        public string RegKSB { get; set; }

        public bool AnyObligations { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }

        public UserType UserType { get; set; }

      
        public ICollection<ATZBUserOffert> Offers { get; set; }

        public ICollection<ATZBUserOrder> Orders { get; set; }


    }
}
