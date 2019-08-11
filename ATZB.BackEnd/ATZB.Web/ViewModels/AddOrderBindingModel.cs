namespace ATZB.Web.ViewModels
{
    using ATZB.Domain;

    public class AddOrderBindingModel
    {
        public string Description { get; set; }

        public decimal PriceTo { get; set; }

        public string Town { get; set; }

        public TypeOfOrder Type { get; set; }
    }
}
