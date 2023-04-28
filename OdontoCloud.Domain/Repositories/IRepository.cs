namespace OdontoCloud.Domain.Repositories
{
    public interface IRepository<T>
    {
        T Save(T entity);
        void Update(T entity);
        T? FindById(int id);
        List<T> FindAll();
        void DeleteById(int id);
        int Count();
    }
}
