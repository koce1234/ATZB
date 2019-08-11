using System;

namespace ATZB.Domain
{
    public class Image
    {
        public Image(string imageLink)
        {
            this.Id = Guid.NewGuid().ToString();
            ImageLink = imageLink;
        }
        public string Id { get; set; }

        public string ImageLink { get; set; }
        
    }
}