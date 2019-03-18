using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceStack.Redis;

namespace MyRedisCache.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var manager = new RedisManagerPool("asitelasticache.coggsz.0001.use1.cache.amazonaws.com:6379");
            using (var client = manager.GetClient())
            {
                client.Set("nameVar", "myName");
                return new string[] { "nameVar", client.Get<string>("nameVar") };
            }
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

    }
}
