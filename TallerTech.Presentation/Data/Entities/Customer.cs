using System.ComponentModel.DataAnnotations;

namespace TallerTech.Presentation.Data.Entities
{
    public class Customer
    {
        [Key]
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Occupation { get; set; }
        public string MartialStatus { get; set; }
    }
}
