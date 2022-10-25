using gdsmx_back_netcoreAPI.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace gdsmx_back_netcoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngagementController : ControllerBase
    {
        private readonly IBLEngagement _blEngagement;
        private readonly ILogger<EngagementController> _logger;

        public EngagementController(IBLEngagement bLEngagement, ILogger<EngagementController> logger)
        {
            _blEngagement = bLEngagement;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        // GET: api/<EngagementController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EngagementController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EngagementController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EngagementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EngagementController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
