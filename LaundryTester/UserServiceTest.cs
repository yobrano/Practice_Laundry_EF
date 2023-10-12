using Laundry.Data;
using Laundry.Service;
using Laundry.Models;
using Microsoft.Identity.Client;

namespace LaundryTester
{
    public class UserServiceTest
    {
        [Fact]
        public void userServiceCreation()
        {
            var context = new LaundryDBContext();
            var userService = new UserService(context);
            Assert.NotNull(userService);
        }

        [Fact]
        public void userCreation()
        {
            var context = new LaundryDBContext();
            var userService = new UserService(context);
            var user = userService.CreateUser("Brian", "Mburu", "Murigi", "developer");
            var brian = context.User
                .Where(usr => usr.Role == "developer")
                .ToList();
            Assert.Single(brian);
            Assert.IsType<User>(user);
        }
    }
}