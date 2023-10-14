using Laundry.Data;
using Laundry.Models;
using Laundry.Utils;
using Newtonsoft.Json;

namespace Laundry.Services
{
    public class LaundryServiceMethods
    {
        private LaundryDBContext Context;
        private LaundryFileManager FileManager= new LaundryFileManager();

        public LaundryServiceMethods(LaundryDBContext context) 
        {
            this.Context = context;
            
        }

        
        public LaundryService CreateService(string label, string description, decimal price)
        {
            var service = new LaundryService()
            {
                Label = label,
                Description = description,
                Price = price
            }; 
            
            this.Context.Add(service);
            this.Context.SaveChanges();
            return service;
        }


        public bool ImportServices(string fileName)
        {
            var status = false;
            var filePath= FileManager.GetImportFilePath(fileName);
            
            try{
                var fileContents = File.ReadAllText(filePath);
                var services = JsonConvert.DeserializeObject<List<LaundryService>>(fileContents);
                if(services !=null) {
                    foreach(var service in services)
                        {this.Context.Add(service);}
                    this.Context.SaveChanges();

                    status = true;
                }
            }catch (Exception) { throw;  }

            return status;
        }

        public bool ExportServices(string fileName)
        {
            var status = false; 
            var filePath = FileManager.GetExportFilePath(fileName);
            var services = this.Context.LaundryService.ToList();
            try
            {
                var fileContent = JsonConvert.SerializeObject(services, Formatting.Indented);
                File.WriteAllText(filePath, fileContent);
                status = true;
            }catch(Exception) { throw; }            
            return status;
        }
    
    }
}
