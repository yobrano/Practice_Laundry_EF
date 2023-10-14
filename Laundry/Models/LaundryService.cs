
using System.ComponentModel.DataAnnotations.Schema;

namespace Laundry.Models
{
    public class LaundryService
    {
        public int Id { get; set; }
        public string Label { get; set; } = null!;
        public string? Description { get; set; }
        [Column(TypeName="decimal(6, 2)")]
        public decimal? Price { get; set; }

    }
}
