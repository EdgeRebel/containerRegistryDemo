using System.Collections.Generic;

namespace BuildPipelineEditDockerProject.Models
{
    public interface IRepository<T>
    {
        public void AddItem(T t);
        public IEnumerable<T> GetMovies();
        public T GetMovieById(int id);
    }
}