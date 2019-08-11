using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ATZB.Services.BaseServices
{
    public interface ICloudDinaryService
    {
        Task<string> CreateImageAsync(IFormFile formfile, string fileName);
    }
}
