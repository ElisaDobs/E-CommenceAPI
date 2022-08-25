namespace E_CommenceAPI.Common
{
    public static class ECommenceConfigurationManager
    {
        private static IConfigurationRoot? configuration;
        public static void InitConfiguration()
        {
                configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public static string GetConnectionString(string key)
        {
            return configuration.GetConnectionString(key);
        }
        public static string GetSMTPServerInfo(string key)
        {
            return configuration.GetValue<string>("Smtp:" + key);
        }
        public static int GetSMTPServerPort(string key)
        {
            return configuration.GetValue<int>("Smtp:" + key);
        }

        public static string GetAuthSettings(string key)
        {
            return configuration.GetValue<string>("Authorisation:" + key);
        }
    }
}
