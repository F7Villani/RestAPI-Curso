using RestAPI.Models;
using RestAPI.Repository;
using System.Collections.Generic;

namespace RestAPI.Business.Implementations
{
    public class PersonBusiness : IPersonBusiness
    {
        private IPersonRepository _repository;

        public PersonBusiness(IPersonRepository repository)
        {
            _repository = repository;
        }

        public List<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public Person GetById(long id)
        {
            return _repository.GetById(id);
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }
        
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

    }
}
