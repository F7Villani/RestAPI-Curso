using RestAPI.Data.Converter.VO;
using System.Collections.Generic;

namespace RestAPI.Business
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);

        PersonVO GetById(long id);

        PersonVO Update(PersonVO person);

        List<PersonVO> GetAll();

        void Delete(long id);
    }
}
