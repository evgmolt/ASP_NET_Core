using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TemperatureController : ControllerBase
    {
        private readonly TemperatureHolder _holder;

        public TemperatureController(TemperatureHolder holder)
        {
            this._holder = holder;
        }

        [HttpPost("create")] //Возможность сохранить температуру в указанное время
        public IActionResult Create([FromQuery] int temperatureS, [FromQuery] DateTime timeToAdd)
        {
            if (timeToAdd == null)
            {
                timeToAdd = DateTime.Now;
            }
            _holder.TemperatureList.Add(new Temperature(timeToAdd, temperatureS));
            return Ok();
        }

        [HttpPut("update")] //Возможность отредактировать показатель температуры в указанное время
        public IActionResult Update([FromQuery] DateTime timeToChange, [FromQuery] int newTemperature)
        {
            for (int i = 0; i < _holder.TemperatureList.Count; i++)
            {
                if (_holder.TemperatureList[i].Date == timeToChange)
                {
                    _holder.TemperatureList[i].TemperatureValue = newTemperature;                    
                }
            }
            return Ok();
        }

        [HttpDelete("deleteinterval")] //Возможность удалить показатель температуры в указанный промежуток времени
        public IActionResult DeleteInterval([FromQuery] DateTime timeFrom, [FromQuery] DateTime timeTo)
        {
            for (int i = 0; i < _holder.TemperatureList.Count(); i++)
            {
                if (_holder.TemperatureList[i].Date >= timeFrom && _holder.TemperatureList[i].Date <= timeTo)
                {
                    _holder.TemperatureList.RemoveAt(i);
                }
            }
            return Ok();
        }

        [HttpGet("readinterval")] //Возможность прочитать список показателей температуры за указанный промежуток времени
        public IActionResult ReadInterval([FromQuery] DateTime timeFrom, [FromQuery] DateTime timeTo)
        {
            List<Temperature> resultList = new List<Temperature>();
            for (int i = 0; i < _holder.TemperatureList.Count(); i++)
            {
                if (_holder.TemperatureList[i].Date >= timeFrom && _holder.TemperatureList[i].Date <= timeTo)
                    resultList.Add(_holder.TemperatureList[i]);
            }
            return Ok(resultList);
        }
    }
}
