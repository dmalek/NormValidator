using System.ComponentModel.DataAnnotations;

namespace NormValidator.Test
{
    internal record Player
    {
        [Required]
        public string FirstName { get; set; } = String.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; } = 0;
    }
}
