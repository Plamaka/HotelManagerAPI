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
                FeatureName = feature.FeatureName
            };
        }

        public static Feature ToFeatureFromDTO(this FeatureDTO featureDTO)
        {
            return new Feature
            {
                FeatureName = featureDTO.FeatureName
            };
        }
    }
}
