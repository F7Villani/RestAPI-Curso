using RestAPI.Data.VO;
using System.Collections.Generic;

namespace RestAPI.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
       
        BookVO GetById(long id);
        
        BookVO Update(BookVO book);

        List<BookVO> GetAll();

        void Delete(long id);
    }
}
