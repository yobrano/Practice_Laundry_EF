using Laundry.Data;
using Laundry.Models;
using Laundry.Utils;
using Newtonsoft.Json;

namespace Laundry.Services
{
    public class CustomerMethods
    {
        LaundryDBContext Context;
        LaundryFileManager FileManger = new LaundryFileManager();

        public CustomerMethods(LaundryDBContext context) 
        {
            this.Context = context;
        }


        public Customer CreateCustomer(int userId)
        {
            var customer = new Customer(){ UserId = userId };
            this.Context.Customer.Add(customer);
            this.Context.SaveChanges();

            return customer;
        }


        public bool ImportCustomers(string fileName)
        {
            // Locate and read the file contents
            // Deserialize contents 
            // Create DB entries

            var status = false;
            var filePath = this.FileManger.GetImportFilePath(fileName);

            try{
                var fileContents = File.ReadAllText(filePath);
                var customers = JsonConvert.DeserializeObject<List<Customer>>(fileContents);

                if (customers == null) { return status;  }

                foreach (var customer in customers)
                    {this.Context.Add(customer);}
                this.Context.SaveChanges();

                status = true;

            }catch (Exception){throw; }
            return status;
        }


        public bool ExportCustomers(string fileName) 
        {
            // Read all customers.
            // Serialize the customers.
            // Locate file and writeout.

            var status = false;
            var customers = this.Context.Customer.ToList();
            try{
                var fileContents = JsonConvert.SerializeObject(customers, Formatting.Indented);
                var filePath = this.FileManger.GetExportFilePath(fileName);
                File.WriteAllText(filePath, fileContents);
                status = true;
            
            }catch(Exception){throw;}
            return status;
        }
    }
}
