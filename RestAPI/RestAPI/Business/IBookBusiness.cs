using RestAPI.Models;
using System.Collections.Generic;

namespace RestAPI.Business
{
    public interface IBookBusiness
    {
        Book Create(Book book);
       
        Book GetById(long id);
        
        Book Update(Book book);

        List<Book> GetAll();

        void Delete(long id);
    }
}
