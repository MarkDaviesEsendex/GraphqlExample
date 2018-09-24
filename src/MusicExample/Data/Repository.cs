using System.Collections.Generic;
using System.Linq;
using Music.Web.Api.Data.Models;

namespace Music.Web.Api.Data
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