using Microsoft.EntityFrameworkCore;
using MovieAplication.WebApi.Entities.Data;
using MovieAplication.WebApi.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MovieAplication.WebApi.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class , new()
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public T AddT(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
            
        }

        public void DeleteT(int id)
        {
            var delete = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(delete);
            _context.SaveChanges();

        }

        public IList<T> GetAll()
        {
         return  _context.Set<T>().ToList();
        }

        public T GetId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public T UpdateT(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }
    }
}
