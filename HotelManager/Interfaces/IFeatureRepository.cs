using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IFeatureRepository
    {
        List<Feature> GetAll();

        Feature GetById(int Id);

        bool Add(Feature Feature);

        bool Update(Feature feature);

        bool Delete(Feature feature);

        bool Save();
    }
}
