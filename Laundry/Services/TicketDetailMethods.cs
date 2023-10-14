using Laundry.Data;
using Laundry.Models;
using Laundry.Utils;
using Newtonsoft.Json;

namespace Laundry.Services
{
    public class TicketDetailMethods
    {
        LaundryDBContext Context;
        LaundryFileManager FileManager = new LaundryFileManager();

        public TicketDetailMethods(LaundryDBContext context) => Context = context;
  

        public TicketDetail CreateTicketDetail(int ticket, int service, int index, DateTime? endTime)
        {
            var ticketDetail = new TicketDetail
            {
                TicketId = ticket,
                LaundryServiceId = service,
                Index = index,
                EndTime = endTime
            };
            Context.Add(ticketDetail);
            Context.SaveChanges();
            return ticketDetail;
        }

        public List<TicketDetail> ImportTicketDetail(string fileName)
        {
            var fileContents = FileManager.ReadImportFileContents(fileName);
            var ticketDetails = JsonConvert.DeserializeObject<List<TicketDetail>>(fileContents);
            if( ticketDetails == null) { return new List<TicketDetail>(); }
            foreach(var ticketDetail in ticketDetails)
                { Context.Add(ticketDetail); }
            Context.SaveChanges();
            return ticketDetails;
        }

        public string ExportTicketDetail(string fileName)
        {
            var ticketDetails = Context.TicketDetail.ToList();
            var fileContents = JsonConvert.SerializeObject(ticketDetails, Formatting.Indented);
            FileManager.WriteExportFileContents(fileName, fileContents);
            return fileContents;
        }
    }
}
