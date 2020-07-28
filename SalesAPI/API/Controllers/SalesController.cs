using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public SalesController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
    }
}
