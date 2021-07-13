using System.Data.SQLite;

namespace MetricsAgent.DAL.Interfaces
{
    public interface IConnectionManager
    {
        SQLiteConnection CreateOpenedConnection();         
    }
}
