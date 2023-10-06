using System.ComponentModel.DataAnnotations;

namespace NormValidator.Test
{
    internal record Player
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = String.Empty;

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        public IEnumerable<string> Sports { get; set; }

    }
}
