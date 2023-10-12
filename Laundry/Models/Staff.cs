using System.ComponentModel.DataAnnotations;


namespace Laundry.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string JobTitle { get; set; } = null!;
        public ICollection<Ticket> Tickets { get; set; } = null!;

    }
}
