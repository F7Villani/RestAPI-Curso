using RestAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RestAPI.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private volatile int count;
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {

        }

        public List<Person> GetAll()
        {
            List<Person> people = new List<Person>();
            for(int i=0; i<8; i++)
            {
                Person person = MockPerson(i);
                people.Add(person);
            }
            return people;
        }


        public Person GetById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Felipe",
                LastName = "Villani",
                Address = "Brazil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPerson(int i)
        {
            return new Person()
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Perosn Last Name" + i,
                Address = "Person Address" + i,
                Gender = (i%2) == 0? "Male" : "Female"

            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
