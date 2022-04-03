using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProgressFit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TosController : ControllerBase
    {
        // GET: api/<TosController>
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }

        // GET api/<TosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
