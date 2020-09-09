using Business.Services.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly ISeriesService<Series> _seriesService;

        public SeriesController( ISeriesService<Series> seriesService)
        {
            _seriesService = seriesService;
        }

        [HttpGet]
        public IEnumerable<Series> GetAll()
        {
            var series = _seriesService.FilterBy(
                filter => filter.Name != "");

            return series;
        }

        [HttpGet("{id}")]
        public Series GetById(int id)
        {
            return _seriesService.FindById(id);
        }

        [HttpGet("search")]
        public IEnumerable<Series> GetByTitle(string name)
        {
            var series = _seriesService.FindByName(name);
            return series;
        }

        [HttpPost]
        public IActionResult Create(Series series)
        {
            _seriesService.InsertOne(series);
            return Ok();
        }


    }
}