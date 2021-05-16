namespace Domain
{
    public static class AppSettings
    {
        private static string ConnectionString { get; set; }

        public static void SetConnectionString(string connectionString)
        {
            if (!string.IsNullOrEmpty(ConnectionString))
                return;

            ConnectionString = connectionString;
        }

        public static string GetConnectionString()
        {
            return ConnectionString;
        }
    }
}