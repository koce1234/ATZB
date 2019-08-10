﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace ATZB.Services.BaseServices
{
    public class CloudDinaryService : ICloudDinaryService
    {

        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly Cloudinary _cloudinaryUtility;

        public CloudDinaryService(IHostingEnvironment hostingEnvironment,
            Cloudinary cloudinaryUtility)
        {
            this._cloudinaryUtility = cloudinaryUtility;
            this._hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> CreateImageAsync(IFormFile formImage, string fileName)
        {
            byte[] destinationData;

            using (var ms = new MemoryStream())
            {
                await formImage.CopyToAsync(ms);
                destinationData = ms.ToArray();
            }

            UploadResult uploadResult = null;

            using (var ms = new MemoryStream(destinationData))
            {
                ImageUploadParams uploadParams = new ImageUploadParams
                {
                    Folder = "images_img",
                    File = new FileDescription(fileName, ms)
                };

                uploadResult = this._cloudinaryUtility.Upload(uploadParams);

            }

            return uploadResult?.SecureUri.AbsoluteUri;
        }
    }
}
