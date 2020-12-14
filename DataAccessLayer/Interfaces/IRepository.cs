using System;
using System.Collections.Generic;
using System.Text;

namespace Data_Access_Layer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //IEnumerable<T> GetAll();
        List<T> Get(string connectionString);
        //IEnumerable<T> Find(Func<T, Boolean> predicate);
        //void Create(T item);
        //void Update(T item);
        //void Delete(int id);
    }
}
