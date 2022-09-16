using RestAPI.Data.Contract.Implementations;
using RestAPI.Data.VO;
using RestAPI.Models;
using RestAPI.Repository;
using System.Collections.Generic;

namespace RestAPI.Business.Implementations
{
    public class BookBusiness : IBookBusiness
    {
        private IRepository<Book> _repository;
        private readonly BookConverter _converter;

        public BookBusiness(IRepository<Book> repository)
        {
            _repository = repository;
            _converter = new BookConverter();
        }

        public List<BookVO> GetAll()
        {
            return _converter.Parse(_repository.GetAll());
        }

        public BookVO GetById(long id)
        {
            return _converter.Parse(_repository.GetById(id));
        }

        public BookVO Create(BookVO book)
        {
            Book bookEntity = _converter.Parse(book);
            bookEntity = _repository.Create(bookEntity);
            return _converter.Parse(bookEntity);
        }
        
        public BookVO Update(BookVO book)
        {
            Book bookEntity = _converter.Parse(book);
            bookEntity = _repository.Update(bookEntity);
            return _converter.Parse(bookEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
