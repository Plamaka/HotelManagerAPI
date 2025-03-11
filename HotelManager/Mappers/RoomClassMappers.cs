using HotelManager.DTOs;
using HotelManager.Models;

namespace HotelManager.Mappers
{
    public static class RoomClassMappers
    {
        public static RoomClassDTO ToRoomClassDTO(this RoomClass roomClass, List<Room> Rooms)
        {
            return new RoomClassDTO
            {
                Id = roomClass.Id,
                ClassName = roomClass.ClassName,
                Description = roomClass.Description,
                Capacity = roomClass.Capacity,
                AllowsPet = roomClass.AllowsPet,
                BasePrice = roomClass.BasePrice,
                TotalRooms = Rooms.Where(r => r.RoomClassId == roomClass.Id && r.RoomStatus.StatusName == "Free").Count(),
                Features = roomClass.RoomClassFeatures.Select(f => new FeatureDTO {  FeatureName = f.Feature.FeatureName }).ToList()
            };
        }

        public static RoomClass ToRoomClassFromDTO(this CreateRoomClassDTO roomClassDTO, List<Room> Rooms)
        {
            var roomClass = new RoomClass()
            {
                ClassName = roomClassDTO.ClassName,
                Capacity = roomClassDTO.Capacity,
                Description = roomClassDTO.Description,
                AllowsPet = roomClassDTO.AllowsPet,
                BasePrice = roomClassDTO.BasePrice,
                RoomClassFeatures = roomClassDTO.FeaturesId.Select(id => new RoomClassFeature { FeatureId = id }).ToList()
            };

            roomClass.TotalRooms = Rooms.Where(r => r.RoomClassId == roomClass.Id).Count() + 1;

            return roomClass;
        }

        public static RoomClass UpdateToRoomClassFromDTO(this CreateRoomClassDTO roomClassDTO, List<int> existingFeatures)
        {
            return new RoomClass
            {
                ClassName = roomClassDTO.ClassName,
                Description = roomClassDTO.Description,
                Capacity = roomClassDTO.Capacity,
                AllowsPet = roomClassDTO.AllowsPet,
                BasePrice = roomClassDTO.BasePrice,
                RoomClassFeatures = existingFeatures.Select(id => new RoomClassFeature { FeatureId = id }).ToList()
            };
        }
    }
}
