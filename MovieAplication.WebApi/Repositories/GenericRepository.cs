﻿using MovieAplication.WebApi.Entities.Data;
using MovieAplication.WebApi.Interfaces;
using System.Collections.Generic;

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

            throw new System.NotImplementedException();
        }

        public void DeleteT(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T GetId(int id)
        {
            throw new System.NotImplementedException();
        }

        public T UpdateT(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
