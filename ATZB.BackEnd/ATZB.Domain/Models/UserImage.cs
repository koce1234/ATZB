using System;

namespace ATZB.Domain.Models
{
    public class Image
    {
        public Image(string imageLink)
        {
            Id = Guid.NewGuid().ToString();
            ImageLink = imageLink;
        }
        public string Id { get; set; }

        public string ImageLink { get; set; }

    }
}