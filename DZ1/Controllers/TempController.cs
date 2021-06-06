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
    public class TempController : ControllerBase
    {
        private ValuesHolder _holder;

        public TempController(ValuesHolder holder)
        {
            _holder = holder;
        }

        //Возможность сохранить температуру в указанное время
        [HttpPost("create")]
        public IActionResult Create([FromQuery] DateTime date, int temp)
        {
            if (!_holder.Values.ContainsKey(date))
            {
                _holder.Values.Add(date, temp);
            }
            return Ok();
        }

        //Возможность прочитать список показателей температуры за указанный промежуток времени
        [HttpGet("read")]
        public IActionResult Read([FromQuery] DateTime date1, DateTime date2)
        {
            var tmpHolder = new ValuesHolder();
            if (_holder.Values != null)
            {            
                foreach (KeyValuePair<DateTime, int> keyValue in _holder.Values)
                {
                    if (keyValue.Key >= date1 && keyValue.Key <= date2)
                    {
                        tmpHolder.Values.Add(keyValue.Key, keyValue.Value);
                    }
                }
            }
            return Ok(tmpHolder.Values);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] DateTime date, int temp)
        {
            if (_holder.Values.ContainsKey(date))
            {
                _holder.Values.Remove(date);
                _holder.Values.Add(date, temp);
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DateTime date1, DateTime date2)
        {
            foreach (KeyValuePair<DateTime, int> keyValue in _holder.Values)
            {
                if (keyValue.Key >= date1 && keyValue.Key <= date2)
                {
                    _holder.Values.Remove(keyValue.Key);
                }
            }
            return Ok();
        }
    }
}
