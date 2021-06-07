using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DZ1.Controllers
{
    [Route("api/crud")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private ValuesHolder _holder;

        public TemperatureController(ValuesHolder holder)
        {
            _holder = holder;
        }

        //Возможность сохранить температуру в указанное время
        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime date, int temperature)
        {
            if (!_holder.Values.ContainsKey(date))
            {
                _holder.Values.Add(date, temperature);
            }
            return Ok();
        }

        //Возможность прочитать список показателей температуры за указанный промежуток времени
        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime startdate, DateTime enddate)
        {
            var temporaryHolder = new ValuesHolder();
            foreach (KeyValuePair<DateTime, int> keyValue in _holder.Values)
            {
                if (keyValue.Key >= startdate && keyValue.Key <= enddate)
                {
                    temporaryHolder.Values.Add(keyValue.Key, keyValue.Value);
                }
            }
            return Ok(temporaryHolder.Values);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, int temperature)
        {
            if (_holder.Values.ContainsKey(date))
            {
                _holder.Values.Remove(date);
                _holder.Values.Add(date, temperature);
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime startdate, DateTime enddate)
        {
            var listKeyToRemove = new List<DateTime>();
            foreach (KeyValuePair<DateTime, int> keyValue in _holder.Values)
            {                
                if (keyValue.Key >= startdate && keyValue.Key <= enddate)
                {
                    listKeyToRemove.Add(keyValue.Key);
                }
            }
            foreach (DateTime KeyToRemove in listKeyToRemove)
            {
                _holder.Values.Remove(KeyToRemove);
            }            
            return Ok();
        }
    }
}
