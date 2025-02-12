using HotelManager.DTOs;
using HotelManager.Models;

namespace HotelManager.Mappers
{
    public static class FeatureMappers
    {
        public static FeatureDTO ToFeatureDTO(this Feature feature)
        {
            return new FeatureDTO
            {
                Id = feature.Id,
                FeatureName = feature.FeatureName
            };
        }

        public static Feature ToFeatureFromDTO(this FeatureDTO featureDTO)
        {
            return new Feature
            {
                Id = featureDTO.Id,
                FeatureName = featureDTO.FeatureName
            };
        }
    }
}
