using OdontoCloud.Domain.Entities;
using OdontoCloud.Domain.Repositories;
using OdontoCloud.Infrastructure.Context;

namespace OdontoCloud.Infrastructure.Repositories
{
    public class FuncionarioRepository : IRepository<Funcionario>
    {
        private readonly OdontoCloudDBContext _context;

        public FuncionarioRepository(OdontoCloudDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Count()
        {
            return _context.Funcionario.Count();
        }

        public void DeleteById(int id)
        {
            Funcionario find = _context.Funcionario.Where(a => a.Id == id).First();
            _context.Funcionario.Remove(find);
            _context.SaveChanges();
        }

        public List<Funcionario> FindAll()
        {
            return _context.Funcionario.ToList();
        }

        public Funcionario? FindById(int id)
        {
            return _context.Funcionario.Find(id);
        }

        public Funcionario Save(Funcionario entity)
        {
            var result = _context.Funcionario.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Update(Funcionario entity)
        {
            _context.Funcionario.Update(entity);
            _context.SaveChanges();
        }
    }
}
