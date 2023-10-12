using Laundry.Service;
using Laundry.Data;
using Laundry.Services;

public class Program
{
    public static void Main(string[] args)
    {
        var context = new LaundryDBContext();
        var customerSevice = new CustomerService(context);
        var staffService = new StaffService(context);
        var userService = new UserService(context);


        customerSevice.ImportCustomers("Customer (1).json");
        staffService.ImportStaff("Staff (1).josn");

        var userSharon = context.User
            .Where(user => user.FirstName == "Sharon")
            .FirstOrDefault();
        if(userSharon != null) 
        {

            //customerSevice.CreateCustomer(userSharon.Id);
            customerSevice.ExportCustomers("Customer (2).json");

        }


        var userBrian = context.User
            .Where(user => user.FirstName == "Brian")
            .FirstOrDefault();
        if(userBrian != null)
        {
            //staffService.CreateStaff(userBrian.Id, "owner");
            staffService.ExportStaff("Staff (2).json");
        }
    
    }
}