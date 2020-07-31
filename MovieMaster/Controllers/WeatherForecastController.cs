using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieMaster;
using ServiceLayer;
using ServiceLayer.Model;

namespace MovieWorldApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private IMovie _movie;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMovie movie)
        {
            _logger = logger;
            _movie = movie;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        /// <summary>
        /// The method takes search string and return list of actors from database
        /// </summary>
        /// <param name="search"></param>
        /// <returns> List of Actors</returns>
        [HttpGet("actor")]
        public async Task<ListViewModel> Actor(string search)
        {
            var test = await _movie.getActor(search);
            return test;
        }

        [HttpPost("actor")]
        public async Task<ListViewModel> addActor([FromBody] MovieViewModel movieViewModel)
        {
            var test = await _movie.getActor("A");
            return test;
        }
    }
}
