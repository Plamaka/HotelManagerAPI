﻿using HotelManager.Models;

namespace HotelManager.Interfaces
{
    public interface IRoomClassRepository
    {
        List<RoomClass> GetAll();

        RoomClass GetById(int Id);

        bool RoomClassExists(int id);

        bool Add(RoomClass roomClass);

        bool Update(RoomClass roomClass);

        bool Delete(RoomClass roomClass);

        bool Save();
    }
}
