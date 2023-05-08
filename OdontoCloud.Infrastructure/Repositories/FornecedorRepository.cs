using OdontoCloud.Domain.Entities;
using OdontoCloud.Domain.Repositories;
using OdontoCloud.Infrastructure.Context;

namespace OdontoCloud.Infrastructure.Repositories
{
    public class FornecedorRepository : IRepository<Fornecedor>
    {
        private readonly OdontoCloudDBContext _context;

        public FornecedorRepository(OdontoCloudDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Count()
        {
            return _context.Fornecedor.Count();
        }

        public void DeleteById(int id)
        {
            Fornecedor find = _context.Fornecedor.Where(a => a.Id == id).First();
            _context.Fornecedor.Remove(find);
            _context.SaveChanges();
        }

        public List<Fornecedor> FindAll()
        {
            return _context.Fornecedor.ToList();
        }

        public Fornecedor? FindById(int id)
        {
            return _context.Fornecedor.Find(id);
        }

        public Fornecedor Save(Fornecedor entity)
        {
            var result = _context.Fornecedor.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Update(Fornecedor entity)
        {
            _context.Fornecedor.Update(entity);
            _context.SaveChanges();
        }
    }
}
