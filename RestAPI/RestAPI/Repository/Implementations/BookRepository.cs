using RestAPI.Models;
using RestAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPI.Repository.Implementations
{
    public class BookRepository : IBookRepository
    {
        private MySQLContext _context;

        public BookRepository(MySQLContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(long id)
        {
            return _context.Books.SingleOrDefault(p => p.Id == id);
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Add(book);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return book;
        }
        
        public Book Update(Book book)
        {
            if (!Exists(book.Id)) return null;
            
            Book bookToUpdate = _context.Books.SingleOrDefault(p => p.Id == book.Id);

            if(bookToUpdate != null)
            {
                try
                {
                    _context.Entry(bookToUpdate).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return book;
        }

        public void Delete(long id)
        {
            Book bookToUpdate = _context.Books.SingleOrDefault(p => p.Id == id);

            if (bookToUpdate != null)
            {
                try
                {
                    _context.Books.Remove(bookToUpdate);
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
            return _context.Books.Any(p => p.Id == id);
        }
    }
}
