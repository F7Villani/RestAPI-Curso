using RestAPI.Models;
using RestAPI.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPI.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private MySQLContext _context;

        public PersonService(MySQLContext context)
        {
            _context = context;
        }

        #region CRUD

        public List<Person> GetAll()
        {
            return _context.People.ToList();
        }

        public Person GetById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id == id);
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return person;
        }
        
        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();
            
            Person personToUpdate = _context.People.SingleOrDefault(p => p.Id == person.Id);

            if(personToUpdate != null)
            {
                try
                {
                    _context.Entry(personToUpdate).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return person;
        }

        public void Delete(long id)
        {
            Person personToUpdate = _context.People.SingleOrDefault(p => p.Id == id);

            if (personToUpdate != null)
            {
                try
                {
                    _context.People.Remove(personToUpdate);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

        #region Util

        private bool Exists(long id)
        {
            return _context.People.Any(p => p.Id == id);
        }

        #endregion
    }
}
