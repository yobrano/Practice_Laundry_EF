using Laundry.Data;
using Laundry.Services;

public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new LaundryDBContext())
        {
            var customerSevice = new CustomerMethods(context);
            var staffService = new StaffMethods(context);
            var userService = new UserMethods(context);

        }

    }
}