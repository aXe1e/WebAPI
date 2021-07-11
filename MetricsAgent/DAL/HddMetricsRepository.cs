using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    // маркировочный интерфейс
    // необходим, чтобы проверить работу репозитория на тесте-заглушке
    public interface IHddMetricsRepository : IRepository<HddMetric>
    {
    }
    public class HddMetricsRepository : IHddMetricsRepository
    {
        public void Create(HddMetric item)
        {
            var connectionManager = new ConnectionManager();

            using (var cmd = new SQLiteCommand(connectionManager.CreateOpenedConnection()))
            {
                cmd.CommandText = "INSERT INTO hddmetrics (value, time) VALUES(@value, @time)";
                cmd.Parameters.AddWithValue("@value", item.Value);
                cmd.Parameters.AddWithValue("@time", item.Time);
                cmd.Prepare();

                cmd.ExecuteNonQuery();
            }
        }

        public IList<HddMetric> GetByTimePeriod(long fromTime, long toTime)
        {
            var connectionManager = new ConnectionManager();
            using var cmd = new SQLiteCommand(connectionManager.CreateOpenedConnection());

            cmd.CommandText = "SELECT id, value, time FROM hddmetrics WHERE time BETWEEN @fromTime AND @toTime";
            cmd.Parameters.AddWithValue("@fromTime", fromTime);
            cmd.Parameters.AddWithValue("@toTime", toTime);

            var returnList = new List<HddMetric>();

            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // пока есть что читать -- читаем
                while (reader.Read())
                {
                    returnList.Add(new HddMetric
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
