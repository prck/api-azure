using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace azure.Controllers {
  [ApiController]
  [Route("[controller]")]
  public class ValController : ControllerBase {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<ValController> _logger;

    public ValController(ILogger<ValController> logger) {
      _logger = logger;
    }

    [HttpGet]
    public IEnumerable<Val> Get() {
      var rng = new Random();
      return Enumerable.Range(1, 5).Select(index => new Val {
        Date = DateTime.Now.AddDays(index),
        TemperatureC = rng.Next(-20, 55),
        Summary = Summaries[rng.Next(Summaries.Length)]
      })
      .ToArray();
    }
  }
}
