namespace ATZB.Domain
{
    using System;

    public class Image
    {
        public Image(string imageLink)
        {
            this.Id = Guid.NewGuid().ToString();
            ImageLink = imageLink;
        }
        public string Id { get; set; }

        public string ImageLink { get; set; }

        public string UserId { get; set; }

        public ATZBUser User { get; set; }
    }
}