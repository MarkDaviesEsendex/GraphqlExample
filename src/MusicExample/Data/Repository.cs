using System.Collections.Generic;
using System.Linq;
using UserApi.Data.Models;

namespace UserApi.Data
{
    public interface IRepository<T> where T : class, IPersistentObject
    {
        List<T> Get();
    }

    public class Repository<T> : IRepository<T> where T : class, IPersistentObject
    {
        private readonly MusicDbContext _context;

        public Repository(MusicDbContext context)
        {
            _context = context;
        }

        public List<T> Get()
        {
            return _context.Set<T>().ToList();
        }
    }
}