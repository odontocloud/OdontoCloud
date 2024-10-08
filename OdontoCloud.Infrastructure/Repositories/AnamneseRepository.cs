﻿using OdontoCloud.Domain.Entities;
using OdontoCloud.Domain.Repositories;
using OdontoCloud.Infrastructure.Context;

namespace OdontoCloud.Infrastructure.Repositories
{
    public class AnamneseRepository : IRepository<Anamnese>
    {
        private readonly OdontoCloudDBContext _context;

        public AnamneseRepository(OdontoCloudDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Count()
        {
            return _context.Anamnese.Count();
        }

        public void DeleteById(int id)
        {
            Anamnese find = _context.Anamnese.Where(a => a.Id == id).First();
            _context.Anamnese.Remove(find);
            _context.SaveChanges();
        }

        public List<Anamnese> FindAll()
        {
            return _context.Anamnese.ToList();
        }

        public Anamnese? FindById(int id)
        {
            return _context.Anamnese.Find(id);
        }

        public Anamnese Save(Anamnese entity)
        {
            var result = _context.Anamnese.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Update(Anamnese entity)
        {
            _context.Anamnese.Update(entity);
            _context.SaveChanges();
        }
    }
}
