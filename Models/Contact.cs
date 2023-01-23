using System.ComponentModel.DataAnnotations;

namespace MultiPageAppApierce.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Please enter a name.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Please enter a Phone Number.")]
        public string? PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please enter an Address.")]
        public string? Address { get; set; }
        public string? Note { get; set; }

        public string? Slug => Name?.ToLower().ToString();
    }
}
