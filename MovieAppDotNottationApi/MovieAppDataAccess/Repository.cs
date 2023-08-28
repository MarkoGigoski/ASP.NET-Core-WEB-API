using MovieAppDomain.Models;

namespace MovieAppDataAccess
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private MovieAppDbContext _dbContext;

        public Repository(MovieAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            var movie = _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with id {id} does not exist");
            }
            return movie;  
        }

        public void Add(T entity)
        {
            _dbContext.Add<T>(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Update<T>(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _dbContext.Remove<T>(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var movie = GetById(id);

            _dbContext.Remove<T>(movie);
            _dbContext.SaveChanges();
        }

    }
}
