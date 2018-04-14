using System.Collections.Generic;

//Step 10.01
namespace CustomAuthenticationHandler.Auth
{
    public class User
    {
        public User(string key, string name, string email, IEnumerable<string> profiles)
        {
            Key = key;
            Name = name;
            Email = email;
            Profiles = profiles;
        }

        public string Key { get; }
        public string Name { get; }
        public string Email { get; }
        public IEnumerable<string> Profiles { get; }
    }

    public static class Users
    {
        public static IEnumerable<User> RegisteredUsers => new[]
        {
            new User("a123", "Lorem", "lorem@ipsum.com", new[]{ "User" }),
            new User("b456", "Dolor", "dolor@ipsum.com", new[]{ "User", "Admin" }),
            new User("c789", "Sit Amet", "sit.amet@ipsum.com", new[]{ "Other" }),
        };
    }
}
