using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace ATZB.Web.ViewModels.UserTypeRegisters
{
    public class PrivatePersonRegisterBindingModel
    {
        public PrivatePersonRegisterBindingModel()
        {
                this.TypeOfSpecials = new List<TypeOfSpecial>();
                this.Images = new List<IFormFile>();
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string EGN  { get; set; }

        public string LkNumber { get; set; }

        public bool AnyObligations { get; set; }

        public string Password { get; set; }
        public Cities City { get; set; }

        public string ConfirmPassword { get; set; }

       public string Email { get; set; }

       public ICollection<IFormFile> Images { get; set; }

       public ICollection<TypeOfSpecial> TypeOfSpecials { get; set; }

        //MustuPloadFiles
    }
}
