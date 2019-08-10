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
           
            this.Orders = new HashSet<ATZBOrder>();

            this.Offers = new HashSet<ATZBOffert>();
        }

        public string Id { get; set; }
        //a1,a2
        //b1
        public string FirstName { get; set; }

        public string LastName { get; set; }
        //a1,a2
        //b1
        public string StreetAddress { get; set; }

        public string City { get; set; }
        //a1
        //b1
        public string EGN { get; set; }
        //a1
        //b1
        public string LKNummber { get; set; }
        //a1,a2
        //b1
        public string Phone { get; set; }
        //a1,a2
        //b1
        public string ENK { get; set; }
        
        public string DDSNumber { get; set; }
        //b1
        public string RegKSB { get; set; }
        //a1,a2
        //b1
        public bool AnyObligations { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }
        //a1,a2
        public string Email { get; set; }

        public UserType UserType { get; set; }

      
        public ICollection<ATZBOffert> Offers { get; set; }

        public ICollection<ATZBOrder> Orders { get; set; }


    }
}
