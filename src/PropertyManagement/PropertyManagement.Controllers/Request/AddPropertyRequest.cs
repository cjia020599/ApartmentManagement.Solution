using System.ComponentModel.DataAnnotations;

namespace PropertyManagement.Controllers.Request
{
    public class AddPropertyRequest
    {
        [Required]
        public string Unit { get; set; } = null!;
        public string Building { get; set; } = null!;

    }
}
