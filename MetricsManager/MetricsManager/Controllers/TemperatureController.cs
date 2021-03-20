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

        private int? GetTemperatureFromString(string tS)
        {
            if (Int32.TryParse(tS, out int res))
            {
                return res;
            }
            return null;
        }

        private DateTime? GetDateTimeFromString(string tS)
        {
            if (DateTime.TryParse(tS, out DateTime res))
            {
                return res;
            }
            return null;
        }

        public TemperatureController(ValuesHolder holder)
        {
            this.holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] string temperatureS, string timeToAdd)
        {
            int? t = GetTemperatureFromString(temperatureS);
            DateTime? dt = GetDateTimeFromString(timeToAdd);
            if (dt == null)
            {
                dt = DateTime.Now;
            }
            if (t != null)
            {
                holder.TemperatureList.Add(new WeatherForecast((DateTime)dt, (int)t, ""));
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(holder.TemperatureList);
        }

        [HttpGet("readinterval")]
        public IActionResult ReadInterval([FromQuery] string timeFrom, [FromQuery] string timeTo)
        {
            DateTime? dtFrom = GetDateTimeFromString(timeFrom);
            DateTime? dtTo = GetDateTimeFromString(timeTo);
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            for (int i = 0; i < holder.TemperatureList.Count(); i++)
            {
                if (holder.TemperatureList[i].Date > dtFrom && holder.TemperatureList[i].Date < dtTo)
                    resultList.Add(holder.TemperatureList[i]);
            }
            return Ok(resultList);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string timeToChange, [FromQuery] string newTemperature)
        {
            DateTime? dt = GetDateTimeFromString(timeToChange);
            int? t = GetTemperatureFromString(newTemperature);
            if (dt == null || t == null)
            {
                return BadRequest();
            }
            for (int i = 0; i < holder.TemperatureList.Count; i++)
            {
                if (holder.TemperatureList[i].Date == dt)
                {
                    holder.TemperatureList[i].TemperatureC = (int)t;
                    return Ok();
                }
            }
            return BadRequest(); 
        }

        [HttpDelete("deleteinterval")]
        public IActionResult DeleteInterval([FromQuery] string timeFrom, [FromQuery] string timeTo)
        {
            DateTime? dtFrom = GetDateTimeFromString(timeFrom);
            DateTime? dtTo = GetDateTimeFromString(timeTo);
            if (dtFrom == null && dtTo == null)
            {
                return BadRequest();
            }
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            for (int i = 0; i < holder.TemperatureList.Count(); i++)
            {
                if (holder.TemperatureList[i].Date > dtFrom && holder.TemperatureList[i].Date < dtTo)
                {
                    resultList.RemoveAt((int)i);
                }
            }
            return Ok();//Нужно ли Bad Request, если ничего не нашлось и не удалилось?
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string timeToDelete)
        {
            DateTime? dt = GetDateTimeFromString(timeToDelete);
            if (dt == null)
            {
                return BadRequest();
            }
            int? numForDelete = null;
            for (int i = 0; i < holder.TemperatureList.Count; i++)
            {
                if (holder.TemperatureList[i].Date == dt)
                {
                    numForDelete = i;
                    break;
                }
            }
            if (numForDelete != null)
            {
                holder.TemperatureList.RemoveAt((int)numForDelete);
                return Ok();
            }
            return BadRequest();
        }
    }
}
