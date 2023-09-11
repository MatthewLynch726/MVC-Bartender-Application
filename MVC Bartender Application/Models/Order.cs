using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVC_Bartender_Application.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public IEnumerable<Cocktail> Cocktails { get; set; }
    }
}
