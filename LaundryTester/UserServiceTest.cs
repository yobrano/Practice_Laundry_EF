using Laundry.Data;
using Laundry.Services;
using Laundry.Models;


namespace LaundryTester
{
    public class UserServiceTest
    {
        [Fact]
        public void userServiceCreation()
        {
            var context = new LaundryDBContext();
            var userService = new UserMethods(context);
            Assert.NotNull(userService);
        }

        [Fact]
        public void userCreation()
        {
            var context = new LaundryDBContext();
            var userService = new UserMethods(context);
            var user = userService.CreateUser("Jack", "Doe", "K", "developer");
            
            var brian = context.User
                .Where(usr => usr.Id == user.Id )
                .FirstOrDefault();

            Assert.IsType<User>(user);
            
        }
    }
}