using Laundry.Data;
using Laundry.Models;
using Laundry.Utils;
using Newtonsoft.Json;

namespace Laundry.Services
{
    public class TicketsMethods
    {
        LaundryDBContext Context;
        LaundryFileManager FileManager = new LaundryFileManager();

        public TicketsMethods(LaundryDBContext context) {
            this.Context = context;
        }


        // Create Ticket
        public Ticket CreateTicket(string ticketNo, string pickUpLoc, string dropOffLoc)
        {
            var ticket = new Ticket()
            {
                TicketNo = ticketNo,
                PickupLocation= pickUpLoc,
                DropoffLocation= dropOffLoc
            };
            this.Context.Add(ticket);
            this.Context.SaveChanges();

            return ticket;
        }
        // Import Tickets
        public List<Ticket> ImportTickets(string fileName)
        {
            var fileContents = FileManager.ReadImportFileContents(fileName);
            var tickets = JsonConvert.DeserializeObject<List<Ticket>>(fileContents);
            if(tickets != null)
            {
                foreach(var ticket in tickets) 
                    { this.Context.Add(ticket); }
                this.Context.SaveChanges();
            }
            return tickets == null? new List<Ticket>(): tickets;

        }


        // Export Tickets
        public bool ExportTickets(string fileName)
        {
            var tickets = this.Context.Ticket.ToList();
            var fileContents = JsonConvert.SerializeObject(tickets, Formatting.Indented);
            return FileManager.WriteExportFileContents(fileName, fileContents);
        }
    }
}
