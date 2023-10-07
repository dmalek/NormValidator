using System.ComponentModel.DataAnnotations;

namespace NormValidator.Test
{
    internal record Player
    {
        public string Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; } = String.Empty;

        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        public IEnumerable<string> Sports { get; set; }

        public string Email { get; set; }

    }
}
