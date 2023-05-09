namespace TallerTech.Presentation.Data.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int PersonID { get; set; }
        public DateTime DateCreated { get; set; }
        public string MethodOfPurchase { get; set; }
    }
}
