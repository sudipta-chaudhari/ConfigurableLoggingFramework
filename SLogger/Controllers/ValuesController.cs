using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SLog;

namespace SLogger
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(SLogAction))]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
