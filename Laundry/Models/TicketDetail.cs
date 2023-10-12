using System.ComponentModel.DataAnnotations;


namespace Laundry.Models
{
    public class TicketDetail
    {
        public int Id { get; set; }
        public Ticket TicketNo { get; set; } = null!;
        public LaundryService Service { get; set; } = null!;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; } = DateTime.Now;
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }

    }
}
