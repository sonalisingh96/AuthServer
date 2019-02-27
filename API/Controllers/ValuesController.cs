using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //Add the code to repo
        //Install Fiddler
        

        [HttpGet("understand-token")]
        public ActionResult<IEnumerable<String>> Understandtoken([FromHeader(Name = "Authorization")] string token)
        {
            var result = new List<String>();
            result.Add("the token is " + token);
            //check if the token is valid
            //Check the name of the user of the token
            //Get the claims of the user of the token
            //Add all of them to the result       
            return result;
        }


        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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
