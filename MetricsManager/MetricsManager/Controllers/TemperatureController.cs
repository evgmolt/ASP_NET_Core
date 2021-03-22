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
        private readonly ValuesHolder holder;

        public TemperatureController(ValuesHolder holder)
        {
            this.holder = holder;
        }

        [HttpPost("create")] //Возможность сохранить температуру в указанное время
        public IActionResult Create([FromQuery] int temperatureS, [FromQuery] DateTime timeToAdd)
        {
            if (timeToAdd == null)
            {
                timeToAdd = DateTime.Now;
            }
            holder.TemperatureList.Add(new WeatherForecast(timeToAdd, temperatureS, ""));
            return Ok();
        }

        [HttpPut("update")] //Возможность отредактировать показатель температуры в указанное время
        public IActionResult Update([FromQuery] DateTime timeToChange, [FromQuery] int newTemperature)
        {
            for (int i = 0; i < holder.TemperatureList.Count; i++)
            {
                if (holder.TemperatureList[i].Date == timeToChange)
                {
                    holder.TemperatureList[i].TemperatureC = newTemperature;                    
                }
            }
            return Ok();
        }



        [HttpDelete("deleteinterval")] //Возможность удалить показатель температуры в указанный промежуток времени
        public IActionResult DeleteInterval([FromQuery] DateTime timeFrom, [FromQuery] DateTime timeTo)
        {
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            for (int i = 0; i < holder.TemperatureList.Count(); i++)
            {
                if (holder.TemperatureList[i].Date > timeFrom && holder.TemperatureList[i].Date < timeTo)
                {
                    resultList.RemoveAt((int)i);
                }
            }
            return Ok();
        }

        [HttpGet("readinterval")] //Возможность прочитать список показателей температуры за указанный промежуток времени
        public IActionResult ReadInterval([FromQuery] DateTime timeFrom, [FromQuery] DateTime timeTo)
        {
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            for (int i = 0; i < holder.TemperatureList.Count(); i++)
            {
                if (holder.TemperatureList[i].Date > timeFrom && holder.TemperatureList[i].Date < timeTo)
                    resultList.Add(holder.TemperatureList[i]);
            }
            return Ok(resultList);
        }
    }
}
