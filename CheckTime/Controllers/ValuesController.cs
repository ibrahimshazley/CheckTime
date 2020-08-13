using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckTime.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CheckTime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly CheckTimeContext _context;
        public ValuesController(CheckTimeContext context)
        {
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues()
        {
            var Values = await _context.TimeCheck.ToListAsync();
            return Ok(Values);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> CheckValue(Guid id)
        {
            var Value = await _context.TimeCheck.FirstOrDefaultAsync(x => x.id == id);
            if (Value.ToDate > DateTime.Now)
            {
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
           // return Ok(Value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
