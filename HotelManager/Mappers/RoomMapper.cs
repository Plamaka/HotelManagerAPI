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
               Id = room.Id,
               RoomStatusId = room.RoomStatusId,
               RoomClassId = room.RoomClassId,
               RoomFloor = room.RoomFloor,
               RoomNumber = room.RoomNumber               
            };
        }

        public static Room ToRoomFromDTO(this CreateRoomDTO roomDTO, RoomStatus roomStatuses)
        {
            return new Room
            {
                RoomStatusId = roomStatuses.Id,
                RoomClassId = roomDTO.RoomClassId,
                RoomFloor = roomDTO.RoomFloor,
                RoomNumber = roomDTO.RoomNumber
            };
        }
    }
}
