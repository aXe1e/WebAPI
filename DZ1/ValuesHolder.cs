using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DZ1
{
    public class ValuesHolder
    {
        public Dictionary<DateTime, int> Values;
        public ValuesHolder()
        {
            Values = new Dictionary<DateTime, int>();
        }
    }
}
