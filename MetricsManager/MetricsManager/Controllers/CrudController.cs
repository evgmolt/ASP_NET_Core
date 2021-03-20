using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CrudController : ControllerBase
    {
        private readonly ValuesHolder holder;

        public CrudController(ValuesHolder holder)
        {
            this.holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] string input)
        {
            holder.Values.Add(input);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(holder.Values);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string stringToUpdate, [FromQuery] string newValue)
        {
            for (int i = 0; i < holder.Values.Count; i++)
            {
                if (holder.Values[i] == stringToUpdate)
                    holder.Values[i] = newValue;
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string input)
        {
            holder.Values = holder.Values.Where(w => w != input).ToList();
            return Ok();
        }
    }
}
