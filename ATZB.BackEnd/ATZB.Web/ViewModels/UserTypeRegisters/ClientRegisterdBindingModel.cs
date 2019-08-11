using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Domain.Models;

namespace ATZB.Web.ViewModels
{
    public class ClientRegisterdBindingModel
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string EGN { get; set; }

        public string LkNumber { get; set; }

        public bool AnyObligations { get; set; }

        public string Password { get; set; }

        public Cities City { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
    }
}
