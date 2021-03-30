using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace BuildPipelineEditDockerProject.Models
{
    //Making this class as single ton
    public class MoviesRepository : IRepository<Movie>
    {
        readonly List<Movie> movies;

        //2nd static instance - this is for thread lock single ton
        private  static readonly object forLock = new object();

        //static instance of the class
        private static MoviesRepository repository = null;

        //1st create private ctor
        public MoviesRepository()
        {
            movies = new List<Movie>();
            movies.Add(new Movie()
            {
                Id = 101,
                Name = "X-Men",
                Duration = 120f
            });
        }

        //3rd create state method that gives instance of this class
        public static MoviesRepository GetInstance
        {
            get
            {
                lock (forLock)
                {
                    if (repository == null) repository = new MoviesRepository();
                    return repository;
                }
            }
        }

        public void AddItem(Movie movie)
        {
            this.movies.Add(movie);
        }

        public IEnumerable<Movie> GetMovies()
        {
            return this.movies;
        }

        public Movie GetMovieById(int id)
        {
            return this.movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
