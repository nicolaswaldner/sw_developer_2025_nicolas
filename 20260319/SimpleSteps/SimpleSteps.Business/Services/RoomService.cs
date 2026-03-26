using SimpleSteps.Data;
using SimpleSteps.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSteps.Business.Services
{
    public class RoomService
    {
        private readonly AppDbContext _context;

        public RoomService(AppDbContext context)
        {
            _context = context;
        }

        public List<Room> GetAll()
        {
            return _context.Rooms.OrderBy(l => l.Name).ToList();
        }
        public List<Room> GetAllByLocationId(long locationId)
        {
            return _context.Rooms
                .Where(r => r.LocationId == locationId)
                .OrderBy(o=>o.Name)
                .ToList();
        }
    }
}
