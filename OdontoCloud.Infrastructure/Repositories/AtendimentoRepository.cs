using OdontoCloud.Domain.Entities;
using OdontoCloud.Domain.Repositories;
using OdontoCloud.Infrastructure.Context;

namespace OdontoCloud.Infrastructure.Repositories
{
    public class AtendimentoRepository : IRepository<Atendimento>
    {
        private readonly OdontoCloudDBContext _context;

        public AtendimentoRepository(OdontoCloudDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Count()
        {
            return _context.Atendimento.Count();
        }

        public void DeleteById(int id)
        {
            Atendimento find = _context.Atendimento.Where(a => a.Id == id).First();
            _context.Atendimento.Remove(find);
            _context.SaveChanges();
        }

        public List<Atendimento> FindAll()
        {
            return _context.Atendimento.ToList();
        }

        public Atendimento? FindById(int id)
        {
            return _context.Atendimento.Find(id);
        }

        public Atendimento Save(Atendimento entity)
        {
            var result = _context.Atendimento.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Update(Atendimento entity)
        {
            _context.Atendimento.Update(entity);
            _context.SaveChanges();
        }
    }
}
