using System;
using System.Collections.Generic;
using System.Linq;
using Music.Web.Api.Data.Models;

namespace Music.Web.Api.Data
{
    public interface IRepository<T> where T : class, IPersistentObject
    {
        List<T> Get();
        List<T> Where(Func<T, bool> expression);
        T Save(T obj);
        ICollection<T> Save(ICollection<T> obj);
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

        public List<T> Where(Func<T, bool> expression)
        {
            return _context.Set<T>().Where(expression).ToList();
        }

        public T Save(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj;
        }
        
        public ICollection<T> Save(ICollection<T> obj)
        {
            _context.Set<T>().AddRange(obj);
            _context.SaveChanges();
            return obj;
        }
    }
}