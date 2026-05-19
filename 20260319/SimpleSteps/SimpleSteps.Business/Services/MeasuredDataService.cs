using SimpleSteps.Data;
using SimpleSteps.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSteps.Business.Services
{
    public class MeasuredDataService
    {
        private readonly AppDbContext _context;

        public MeasuredDataService(AppDbContext context)
        {
            _context = context;
        }

        public List<MeasuredData> GetAll()
        {
            return _context.MeasuredData.OrderByDescending(l => l.MeasuredDateTime).ToList();
        }
        public List<MeasuredData> GetAllBySensorId(long sensorId)
        {
            return _context.MeasuredData
                .Where(r => r.SensorId == sensorId)
                .OrderByDescending(l => l.MeasuredDateTime)
                .ToList();
        }

        public List<MeasuredData> GetAllByAppUserId(long appUserId)
        {
            return _context.MeasuredData
                .Where(r => r.AppUserId == appUserId)
                .OrderByDescending(l => l.MeasuredDateTime)
                .ToList();
        }
    }
}
