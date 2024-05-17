using System.Collections.Generic;
namespace TestWpfProj.Data
{
    public static class UserContext
    {
        public static List<User> Users = new List<User>()
        {
            new User("Guest", null, null),
            new User("User_1", "User_1", "User_1"),
            new User("User_2", "User_2", "User_2"),
        };
    }
}
