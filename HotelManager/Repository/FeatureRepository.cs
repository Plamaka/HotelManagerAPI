using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;

namespace HotelManager.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly HotelManagerDbContext _context;

        public FeatureRepository(HotelManagerDbContext context)
        {
            _context = context;
        }

        public List<Feature> GetAll()
        {
            return _context.Features.ToList();
        }

        public Feature GetById(int id)
        {
            return _context.Features.FirstOrDefault(f => f.Id == id);
        }

        public bool Add(Feature feature)
        {
            _context.Add(feature);
            return Save();
        }

        public bool Delete(Feature feature)
        {
            _context.Remove(feature);
            return Save();
        }

        public bool Update(Feature feature)
        {
            _context.Update(feature);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
