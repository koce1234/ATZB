using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATZB.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace ATZB.Web.ViewModels.UserTypeRegisters
{
    public class ContractorCompanyRegisterBindingModel
    {
        public ContractorCompanyRegisterBindingModel()
        {
                this.TypeOfSpecials = new List<TypeOfSpecial>();
                this.Images = new List<IFormFile>();
        }
        public string CompanyName  { get; set; }

        public string Adress { get; set; }

        public string ENK { get; set; }

        public string DDSNum { get; set; }

        public  string REGKSB { get; set; }

        public Cities City { get; set; }
        public string Mol { get; set; }


        public bool AnyObligations { get; set; }

        public string Password { get; set; }


        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public ICollection<TypeOfSpecial> TypeOfSpecials { get; set; }

        public ICollection<IFormFile> Images { get; set; }
        //MustUploadFiles
    }
}
