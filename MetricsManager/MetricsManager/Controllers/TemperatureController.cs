using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ValuesHolder holder;

        private int? GetTemperatureFromString(string tS)
        {
            int res;
            if (Int32.TryParse(tS, out res))
            {
                return res;
            }
            return null;
        }

        private DateTime? GetDateTimeFromString(string tS)
        {
            DateTime res;
            if (DateTime.TryParse(tS, out res))
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
                dt = DateTime.Now;
            if (t != null)
            {
                holder.TempList.Add(new WeatherForecast((DateTime)dt, (int)t, ""));
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(holder.TempList);
        }

        [HttpGet("readinterval")]
        public IActionResult ReadInterval([FromQuery] string timeFrom, [FromQuery] string timeTo)
        {
            DateTime? dtFrom = GetDateTimeFromString(timeFrom);
            DateTime? dtTo = GetDateTimeFromString(timeTo);
            List<WeatherForecast> resultList = new List<WeatherForecast>();
            for (int i = 0; i < holder.TempList.Count(); i++)
            {
                if (holder.TempList[i].Date > dtFrom && holder.TempList[i].Date < dtTo)
                    resultList.Add(holder.TempList[i]);
            }
            return Ok(resultList);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string timeToChange, [FromQuery] string newTemp)
        {
            DateTime? dt = GetDateTimeFromString(timeToChange);
            int? t = GetTemperatureFromString(newTemp);
            if (dt == null || t == null)
            {
                return BadRequest();
            }
            for (int i = 0; i < holder.TempList.Count; i++)
            {
                if (holder.TempList[i].Date == dt)
                {
                    holder.TempList[i].TemperatureC = (int)t;
                    return Ok();
                }
            }
            return BadRequest(); 
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
            for (int i = 0; i < holder.TempList.Count; i++)
            {
                if (holder.TempList[i].Date == dt)
                {
                    numForDelete = i;
                    break;
                }
            }
            if (numForDelete != null)
            {
                holder.TempList.RemoveAt((int)numForDelete);
                return Ok();
            }
            return BadRequest();
        }
    }
}
