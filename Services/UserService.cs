namespace CustomerManagement.Services
{
    public interface IUserService
    {
        bool ValidateUser(string username, string password);
    }

    public class UserService : IUserService
    {
        // Simulated user store (replace with DB if needed)
        private readonly Dictionary<string, string> _users = new()
    {
        { "admin", "admin" },
        { "john", "doe123" }
    };

        public bool ValidateUser(string username, string password)
        {
            return _users.TryGetValue(username, out var storedPassword) && storedPassword == password;
        }
    }

}
