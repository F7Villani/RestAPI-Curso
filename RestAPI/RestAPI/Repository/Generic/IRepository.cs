using RestAPI.Models;
using RestAPI.Models.Base;
using System.Collections.Generic;

namespace RestAPI.Repository
{
    public interface IRepository<T> where T: BaseEntity
    {
        List<T> GetAll();

        T GetById(long id);

        T Create(T item);

        T Update(T item);

        void Delete(long id);

        bool Exists(long id);

    }
}
