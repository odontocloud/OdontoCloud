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
        T Save(T entity);
        T? FindById(int id);
        List<T> FindAll();
        void DeleteById(int id);
        int Count();
    }
}
