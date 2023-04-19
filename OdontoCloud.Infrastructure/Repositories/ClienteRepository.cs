using OdontoCloud.Domain.Entities;
using OdontoCloud.Domain.Repositories;
using OdontoCloud.Infrastructure.Context;

namespace OdontoCloud.Infrastructure.Repositories
{
    public class ClienteRepository : IRepository<Cliente>
    {
        private readonly OdontoCloudDBContext _context;

        public ClienteRepository(OdontoCloudDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Count()
        {
            return _context.Cliente.Count();
        }

        public void DeleteById(int id)
        {
            Cliente find = _context.Cliente.Where(a => a.Id == id).First();
            _context.Cliente.Remove(find);
            _context.SaveChanges();
        }

        public List<Cliente> FindAll()
        {
            return _context.Cliente.ToList();
        }

        public Cliente? FindById(int id)
        {
            return _context.Cliente.Find(id);
        }

        public Cliente Save(Cliente entity)
        {
            var result = _context.Cliente.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Update(Cliente entity)
        {
            _context.Cliente.Update(entity);
            _context.SaveChanges();
        }
    }
}
