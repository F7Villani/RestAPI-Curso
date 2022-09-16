using RestAPI.Data.Contract.Implementations;
using RestAPI.Data.Converter.VO;
using RestAPI.Models;
using RestAPI.Repository;
using System.Collections.Generic;

namespace RestAPI.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusiness(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonVO> GetAll()
        {
            return _converter.Parse(_repository.GetAll());
        }

        public PersonVO GetById(long id)
        {
            return _converter.Parse(_repository.GetById(id));
        }

        public PersonVO Create(PersonVO personVO)
        {
            Person personEntity = _converter.Parse(personVO);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }
        
        public PersonVO Update(PersonVO personVO)
        {
            Person personEntity = _converter.Parse(personVO);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
