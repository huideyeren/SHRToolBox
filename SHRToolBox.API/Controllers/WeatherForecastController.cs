using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SHRToolBox.Shared.Entities;
using SHRToolBox.Shared.Services;

namespace SHRToolBox.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        WeatherForecastService service = new WeatherForecastService();

        private readonly ILogger<WeatherForecastController> _logger;

        // The Web API will only accept tokens 1) for users, and 2) having the "access_as_user" scope for this API
        static readonly string[] scopeRequiredByApi = new string[] { "access_as_user" };

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            DateTime today = DateTime.Now;
            return service.GetForecastAsync(today)
                          .Result
                          .AsEnumerable();
        }
    }
}
