using OdontoCloud.Domain.Entities;
using OdontoCloud.Domain.Repositories;
using OdontoCloud.Infrastructure.Context;

namespace OdontoCloud.Infrastructure.Repositories
{
    public class DetalheAtendimentoRepository : IRepository<DetalheAtendimento>
    {
        private readonly OdontoCloudDBContext _context;

        public DetalheAtendimentoRepository(OdontoCloudDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Count()
        {
            return _context.DetalheAtendimento.Count();
        }

        public void DeleteById(int id)
        {
            DetalheAtendimento find = _context.DetalheAtendimento.Where(a => a.Id == id).First();
            _context.DetalheAtendimento.Remove(find);
            _context.SaveChanges();
        }

        public List<DetalheAtendimento> FindAll()
        {
            return _context.DetalheAtendimento.ToList();
        }

        public DetalheAtendimento? FindById(int id)
        {
            return _context.DetalheAtendimento.Find(id);
        }

        public DetalheAtendimento Save(DetalheAtendimento entity)
        {
            var result = _context.DetalheAtendimento.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Update(DetalheAtendimento entity)
        {
            _context.DetalheAtendimento.Update(entity);
            _context.SaveChanges();
        }
    }
}
