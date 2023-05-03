using OdontoCloud.Domain.Entities;
using OdontoCloud.Domain.Repositories;
using OdontoCloud.Infrastructure.Context;

namespace OdontoCloud.Infrastructure.Repositories
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly OdontoCloudDBContext _context;

        public ItemRepository(OdontoCloudDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public int Count()
        {
            return _context.Item.Count();
        }

        public void DeleteById(int id)
        {
            Item find = _context.Item.Where(a => a.Id == id).First();
            _context.Item.Remove(find);
            _context.SaveChanges();
        }

        public List<Item> FindAll()
        {
            return _context.Item.ToList();
        }

        public Item? FindById(int id)
        {
            return _context.Item.Find(id);
        }

        public Item Save(Item entity)
        {
            var result = _context.Item.Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public void Update(Item entity)
        {
            _context.Item.Update(entity);
            _context.SaveChanges();
        }
    }
}
