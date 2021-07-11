using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public interface IDotNetMetricsRepository : IRepository<DotNetMetric>
    {
    }
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
        public void Create(DotNetMetric item)
        {
            var connectionManager = new ConnectionManager();
            using (var cmd = new SQLiteCommand(connectionManager.CreateOpenedConnection()))
            {
                cmd.CommandText = "INSERT INTO dotnetmetrics(value, time) VALUES(@value, @time)";
                cmd.Parameters.AddWithValue("@value", item.Value);
                cmd.Parameters.AddWithValue("@time", item.Time);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
        }

        public IList<DotNetMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            var connectionManager = new ConnectionManager();
            using var cmd = new SQLiteCommand(connectionManager.CreateOpenedConnection());

            cmd.CommandText = "SELECT id, value, time FROM dotnetmetrics WHERE time BETWEEN @fromTime AND @toTime";
            cmd.Parameters.AddWithValue("@fromTime", fromTime);
            cmd.Parameters.AddWithValue("@toTime", toTime);

            var returnList = new List<DotNetMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // пока есть что читать -- читаем
                while (reader.Read())
                {
                    returnList.Add(new DotNetMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = reader.GetInt32(2)
                    });
                }
            }

            return returnList;
        }
    }
}
