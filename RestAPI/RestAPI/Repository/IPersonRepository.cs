using RestAPI.Models;
using System.Collections.Generic;

namespace RestAPI.Repository
{
    public interface IPersonRepository
    {
        Person Create(Person person);

        Person GetById(long id);

        Person Update(Person person);

        List<Person> GetAll();

        void Delete(long id);

        bool Exists(long id);

    }
}
