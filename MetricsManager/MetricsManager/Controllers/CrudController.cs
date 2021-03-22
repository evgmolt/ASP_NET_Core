using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace MetricsManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class CrudController : ControllerBase
    {
        private readonly ValuesHolder _holder;

        public CrudController(ValuesHolder holder)
        {
            this._holder = holder;
        }

        [HttpPost("create")]
        public IActionResult Create([FromQuery] string input)
        {
            _holder.Values.Add(input);
            return Ok();
        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            return Ok(_holder.Values);
        }

        [HttpPut("update")]
        public IActionResult Update([FromQuery] string stringToUpdate, [FromQuery] string newValue)
        {
            for (int i = 0; i < _holder.Values.Count; i++)
            {
                if (_holder.Values[i] == stringToUpdate)
                    _holder.Values[i] = newValue;
            }
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] string input)
        {
            _holder.Values = _holder.Values.Where(w => w != input).ToList();
            return Ok();
        }
    }
}
