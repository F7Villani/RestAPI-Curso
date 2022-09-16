using RestAPI.Data.VO;
using RestAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RestAPI.Data.Contract.Implementations
{
    public class BookConverter : IParser<Book, BookVO>, IParser<BookVO, Book>
    {
        public BookVO Parse(Book origin)
        {
            if(origin == null) return null;
            return new BookVO
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<BookVO> Parse(List<Book> origin)
        {
            if (origin == null) return null;
            return origin.Select(book => Parse(book)).ToList();
        }

        public Book Parse(BookVO origin)
        {
            if (origin == null) return null;
            return new Book
            {
                Id = origin.Id,
                Author = origin.Author,
                LaunchDate = origin.LaunchDate,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Book> Parse(List<BookVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(bookVO => Parse(bookVO)).ToList();
        }
    }
}
