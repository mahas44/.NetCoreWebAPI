using Business.Services.Interfaces;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService<Movie> _movieService;

        public MoviesController(IMovieService<Movie> movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IEnumerable<Movie> GetAll()
        {
            var movies = _movieService.FilterBy(
                filter => filter.Title != "");

            return movies;
        }

        [HttpGet("{id}")]
        public Movie GetById(int id)
        {
            return _movieService.FindById(id);
        }

        [HttpGet("discover")]
        public IEnumerable<Movie> GetByReleaseDate(string date)
        {
            return _movieService.FindByReleaseDate(date);
        }

        [HttpGet("search")]
        public IEnumerable<Movie> GetByTitle(string title)
        {
            return _movieService.FindByTitle(title);
        }

    }
}