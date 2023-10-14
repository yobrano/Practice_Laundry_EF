using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Laundry.Models
{
    [Index(nameof(TicketDetail.Index), nameof(TicketDetail.TicketId), IsUnique= true)]
    public class TicketDetail
    {
        public int Id { get; set; }
        public int Index { get; set; } = 0;
        
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
        
        public int LaundryServiceId { get; set; }
        public LaundryService LaundryService { get; set; } = null!;
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? EndTime { get; set; }

    }
}
