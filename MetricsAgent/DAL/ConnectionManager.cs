using MetricsAgent.DAL.Interfaces;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public class ConnectionManager : IConnectionManager
    {
        public const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
        public SQLiteConnection CreateOpenedConnection()
        {
            var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
