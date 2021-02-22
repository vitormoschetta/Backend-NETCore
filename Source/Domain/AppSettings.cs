namespace Domain
{
    public class AppSettings
    {
        public static string ConnectionString { get; private set; }      
        public AppSettings(string con)
        {
            if (ConnectionString != null)
                return;
                
            ConnectionString = con;
        }                
                     
    }
}