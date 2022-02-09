using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class Platform
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        [StringLength(255)]
        public string? LicenseKey { get; set; }

        public ICollection<Command> Commands { get; set; } = new List<Command>();
    }
}
// If the property is DateTime? (nullable) and [Required], then if a malicious user did omit the property in the request, then a ModelState error will be generated because a value is expected in the request, and the view would be returned, therefore the invalid data will not be saved.
//
