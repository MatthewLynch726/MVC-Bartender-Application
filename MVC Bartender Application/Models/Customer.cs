using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MVC_Bartender_Application.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
