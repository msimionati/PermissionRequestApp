using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PermissionRequestApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
      {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<PermissionController> _logger;

        public PermissionController(ILogger<PermissionController> logger)
        {
            _logger = logger;
        }
    }
}
