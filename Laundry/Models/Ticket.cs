using System.ComponentModel.DataAnnotations;


namespace Laundry.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNo { get; set; } = null!;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<TicketDetail> TicketDetails { get; set; } = null!;
        public string? DropoffLocation { get; set; }
        public string? PickupLocation { get; set; }

    }
}
