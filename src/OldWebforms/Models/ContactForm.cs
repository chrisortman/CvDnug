using System.ComponentModel.DataAnnotations;

namespace OldWebforms.Models
{
    public class ContactForm
    {
        [Required]
        public string Name { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}