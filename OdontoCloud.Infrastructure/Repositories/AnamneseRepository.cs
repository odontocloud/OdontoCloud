using OdontoCloud.Domain.Entities;
using OdontoCloud.Domain.Repositories;
using OdontoCloud.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoCloud.Infrastructure.Repositories
{
    public class AnamneseRepository : IRepository<Anamnese>
    {
        private readonly OdontoCloudDBContext _context;

        public AnamneseRepository(OdontoCloudDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Anamnese Add(Anamnese obj)
        {
            var result = _context.Anamnese.Add(obj).Entity;
            _context.SaveChanges();
            return result;
        }

        public Anamnese deleteById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Anamnese> findAll()
        {
            throw new NotImplementedException();
        }

        public Anamnese findById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
