using System.Data.SqlClient;

namespace Kulish.net.DataBase
{
    public class DataBaseContext
    {
        public SqlDataAdapter Users { get; set; }
        public SqlDataAdapter Sneakers { get; set; }
        public SqlDataAdapter Buskets { get; set; }

        private readonly string _connection;

        public DataBaseContext(string connection)
        {
            _connection = connection;

            string command = "SELECT * FROM {0};";

            Users = new SqlDataAdapter(string.Format(command, "dbo.[User]"), connection);
            Sneakers = new SqlDataAdapter(string.Format(command, "dbo.[Sneakers]"), connection);
            Buskets = new SqlDataAdapter(string.Format(command, "dbo.[Basket]"), connection);
        }
    }
}
