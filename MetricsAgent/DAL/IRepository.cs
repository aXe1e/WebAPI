using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.DAL
{
    public interface IRepository<T> where T : class
    {
        IList<T> GetByTimePeriod(long fromTime, long toTime);
        void Create(T item);
    }
}
