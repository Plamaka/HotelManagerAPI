using HotelManager.DTOs;
using HotelManager.Models;

namespace HotelManager.Mappers
{
    public static class RoomMapper
    {
        public static RoomDTO ToRoomDTO(this Room room)
        {
            return new RoomDTO
            {
               Description = room.Description,
               RoomClassId = room.RoomClassId,
               RoomFloor = room.RoomFloor,
               RoomNumber = room.RoomNumber               
            };
        }

        public static Room ToRoomFromDTO(this RoomDTO roomDTO)
        {
            return new Room
            {
                Description = roomDTO.Description,
                RoomClassId = roomDTO.RoomClassId,
                RoomFloor = roomDTO.RoomFloor,
                RoomNumber = roomDTO.RoomNumber
            };
        }
    }
}
