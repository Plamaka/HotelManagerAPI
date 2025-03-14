﻿using HotelManager.Data;
using HotelManager.Interfaces;
using HotelManager.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManager.Repository
{
    public class RoomClassRepository : IRoomClassRepository
    {
        private readonly HotelManagerDbContext _context;

        public RoomClassRepository(HotelManagerDbContext context)
        {
            _context = context;
        }

        public List<RoomClass> GetAll()
        {
            return _context.RoomClasses.ToList();
        }    

        public RoomClass GetById(int Id)
        {
            return _context.RoomClasses.Include(rc => rc.RoomClassFeatures).ThenInclude(rcf => rcf.Feature).FirstOrDefault(rc => rc.Id == Id);
        }

        public bool RoomClassExists(int id)
        {
            return _context.RoomClasses.Any(rc => rc.Id == id);
        }

        public List<RoomClass> SearchByPrice(decimal priceMin,decimal priceMax)
        {
            return _context.RoomClasses.Where(rc => rc.BasePrice >= priceMin && priceMax >= rc.BasePrice).ToList();
        }

        public bool Add(RoomClass roomClass)
        {
            _context.Add(roomClass);
            return Save();
        }

        public bool Delete(RoomClass roomClass)
        {
            _context.Remove(roomClass);
            return Save();
        }

        public bool Update(RoomClass roomClass)
        {
            _context.Update(roomClass);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
