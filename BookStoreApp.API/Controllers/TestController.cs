using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTest")]
        public IEnumerable<Test> Get()
        {
            _logger.LogInformation("Made call to Weather Endpoint");
            try
            {
                //throw new Exception("THis is our logging test exception");
                return Enumerable.Range(1, 5).Select(index => new Test
                {
                    Montant = Random.Shared.NextInt64(),
                    Nom = "test"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Fatal Error Occurred");
                throw;
            }

        }
    }
}