using OdontoCloud.Domain.Entities;
using OdontoCloud.Domain.Repositories;
using OdontoCloud.Infrastructure.Context;

namespace OdontoCloud.Infrastructure.Repositories
{
    public class EnderecoRepository : IRepository<Endereco>
    {
        private readonly OdontoCloudDBContext _context;

        public EnderecoRepository(OdontoCloudDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Count()
        {
            return _context.Endereco.Count();
        }

        public void DeleteById(int id)
        {
            Endereco find = _context.Endereco.Where(a => a.Id == id).First();
            _context.Endereco.Remove(find);
            _context.SaveChanges();
        }

        public List<Endereco> FindAll()
        {
            return _context.Endereco.ToList();
        }

        public Endereco? FindById(int id)
        {
            return _context.Endereco.Find(id);
        }

        public Endereco Save(Endereco entity)
        {
            var result = _context.Endereco.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Update(Endereco entity)
        {
            _context.Endereco.Update(entity);
            _context.SaveChanges();
        }
    }
}
