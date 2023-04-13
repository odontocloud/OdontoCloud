using OdontoCloud.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Domain.Repositories
{
    public interface IRepository<T>
    {
        T Add(T obj);
        T findById(int id);
        List<T> findAll();
        T deleteById(int id);
    }
}
