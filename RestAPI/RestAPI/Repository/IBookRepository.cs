using RestAPI.Models;
using System.Collections.Generic;

namespace RestAPI.Repository
{
    public interface IBookRepository
    {
        Book Create(Book book);

        Book GetById(long id);

        Book Update(Book book);

        List<Book> GetAll();

        void Delete(long id);

        bool Exists(long id);

    }
}
