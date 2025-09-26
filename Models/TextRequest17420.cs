using System.ComponentModel.DataAnnotations;

namespace Api17420.Models
{
    public class TextRequest12345
    {
        [Required]
        public string Texto { get; set; } = string.Empty;
    }
}