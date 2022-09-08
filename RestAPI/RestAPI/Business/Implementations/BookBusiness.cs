using RestAPI.Models;
using RestAPI.Repository;
using System.Collections.Generic;

namespace RestAPI.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private IBookRepository _repository;

        public BookBusiness(IBookRepository repository)
        {
            _repository = repository;
        }

        public List<Book> GetAll()
        {
            return _repository.GetAll();
        }

        public Book GetById(long id)
        {
            return _repository.GetById(id);
        }

        public Book Create(Book book)
        {
            return _repository.Create(book);
        }
        
        public Book Update(Book book)
        {
            return _repository.Update(book);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
