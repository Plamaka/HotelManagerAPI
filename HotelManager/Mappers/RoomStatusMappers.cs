using HotelManager.DTOs;
using HotelManager.Models;

namespace HotelManager.Mappers
{
    public static class RoomStatusMappers
    {
        public static RoomStatusDTO ToRoomStatusDTO(this RoomStatus roomModel)
        {
            return new RoomStatusDTO
            {
                StatusName = roomModel.StatusName
            };
        }

        public static RoomStatus ToRoomStatusFromDTO(this RoomStatusDTO roomStatusDTO)
        {
            return new RoomStatus 
            {
                StatusName = roomStatusDTO.StatusName 
            };
        }
    }
}
