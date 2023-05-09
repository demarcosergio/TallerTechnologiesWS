using System.ComponentModel.DataAnnotations;

namespace TallerTech.Presentation.Data.Entities
{
    public class OrderDetails
    {
        [Key]
        public int OrderID { get; set; }
        public int OrderDetailID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductID { get; set; }
        public string ProductOrigin { get; set; }
    }
}
