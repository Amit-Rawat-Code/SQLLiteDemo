namespace SQLLiteDemo.Security
{
    public static class SessionManager
    {
        public static int UserId { get; private set; }
        public static string Username { get; private set; }
        public static string Role { get; private set; }
        public static DateTime LastActivity { get; private set; }

        public static void Start(int userId, string username, string role)
        {
            UserId = userId;
            Username = username;
            Role = role;
            UpdateActivity();
        }

        public static void UpdateActivity()
        {
            LastActivity = DateTime.Now;
        }

        public static void Clear()
        {
            UserId = 0;
            Username = null;
            Role = null;
        }
    }
}
