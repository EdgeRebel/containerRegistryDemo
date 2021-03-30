using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildPipelineEditDockerProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuildPipelineEditDockerProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IRepository<Movie> _repository;

        public MovieController(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        // GET: api/Movie
        [HttpGet]
        public ActionResult<IEnumerable<Movie>> Get()
        {
            var movies =  _repository.GetMovies();

            if (movies.Count() == 0) return BadRequest("No items in the list");

            return Ok(movies);
        }

        // GET: api/Movie/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Movie> Get(int id)
        {
            var movie = _repository.GetMovieById(id);
            if (movie == null) return BadRequest("No movie with the given id");
            return Ok(movie);
        }

        // POST: api/Movie
        [HttpPost]
        public ActionResult<Movie> Post([FromBody] Movie movie)
        {
            try
            {
                _repository.AddItem(movie);
                return Ok(movie);
            }
            catch (Exception e)
            {

                return BadRequest("Could not add movie");
            }
            
        }

        // PUT: api/Movie/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
