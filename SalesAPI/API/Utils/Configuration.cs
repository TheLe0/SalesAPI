namespace API.Utils
{
    public class Configuration
    {
        private readonly string ConnectionString = @"Data Source=DESKTOP-L45S3A1\MSSQLSERVER01;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Database=SalesDB";
        private Configuration() { }

        private static Configuration _instance;
        private static readonly object _lock = new object();

        public static Configuration GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Configuration();
                    }
                }
            }
            return _instance;
        }

        public string GetConnectionString()
        {
            return _instance.ConnectionString;
        }
    }
}
