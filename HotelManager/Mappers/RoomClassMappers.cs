using HotelManager.DTOs;
using HotelManager.Models;

namespace HotelManager.Mappers
{
    public static class RoomClassMappers
    {
        public static RoomClassDTO ToRoomClassDTO(this RoomClass roomClass)
        {
            return new RoomClassDTO
            {
                Id = roomClass.Id,
                ClassName = roomClass.ClassName,
                Capacity = roomClass.Capacity,
                AllowsPet = roomClass.AllowsPet,
                BasePrice = roomClass.BasePrice,
                Features = roomClass.RoomClassFeatures.Select(f => new FeatureDTO {  FeatureName = f.Feature.FeatureName }).ToList()
            };
        }

        public static RoomClass ToRoomClassFromDTO(this CreateRoomClassDTO roomClassDTO)
        {
            return new RoomClass
            {
                ClassName = roomClassDTO.ClassName,
                Capacity = roomClassDTO.Capacity,
                AllowsPet = roomClassDTO.AllowsPet,
                BasePrice = roomClassDTO.BasePrice,
                RoomClassFeatures = roomClassDTO.FeaturesId.Select(id => new RoomClassFeature { FeatureId = id }).ToList()
            };
        }

        public static RoomClass UpdateToRoomClassFromDTO(this CreateRoomClassDTO roomClassDTO, List<int> existingFeatures)
        {
            return new RoomClass
            {
                ClassName = roomClassDTO.ClassName,
                Capacity = roomClassDTO.Capacity,
                AllowsPet = roomClassDTO.AllowsPet,
                BasePrice = roomClassDTO.BasePrice,
                RoomClassFeatures = existingFeatures.Select(id => new RoomClassFeature { FeatureId = id }).ToList()
            };
        }
    }
}
