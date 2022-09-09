using Microsoft.EntityFrameworkCore;
using RestAPI.Models;
using RestAPI.Models.Base;
using RestAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPI.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MySQLContext _context;
        private DbSet<T> _dataSet;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataSet = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dataSet.ToList();
        }

        public T GetById(long id)
        {
            return _dataSet.SingleOrDefault(p => p.Id == id);
        }

        public T Create(T item)
        {
            try
            {
                _dataSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T Update(T item)
        {
            if (!Exists(item.Id)) return null;

            BaseEntity itemToUpdate = _dataSet.SingleOrDefault(p => p.Id == item.Id);

            if (itemToUpdate != null)
            {
                try
                {
                    _context.Entry(itemToUpdate).CurrentValues.SetValues(item);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return item;
        }

        public void Delete(long id)
        {
            var itemToUpdate = _dataSet.SingleOrDefault(p => p.Id == id);

            if (itemToUpdate != null)
            {
                try
                {
                    _dataSet.Remove(itemToUpdate);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool Exists(long id)
        {
            return _dataSet.Any(p => p.Id == id);
        }


    }
}
