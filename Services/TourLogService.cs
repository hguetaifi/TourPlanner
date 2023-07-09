using System.Collections.Generic;
using System.Linq;
using TourPlanner.Models;
using Microsoft.EntityFrameworkCore;
using TourPlanner.Data;
using log4net;

namespace TourPlanner.Services
{
    public class TourLogService : ITourLogService
    {
        private readonly TourPlannerDbContext _context;

        private static readonly ILog log = LogManager.GetLogger(typeof(App));

        public TourLogService(TourPlannerDbContext context)
        {
            _context = context;
        }

        public List<TourLog> GetAllLogs()
        {
            log.Info("Getting All Tour Logs");
            return _context.TourLogs.Include(tl => tl.Tour).ToList();
        }

        public TourLog GetLogById(int id)
        {
            log.Info("Getting All Tour Logs By Tour Log Id = " + id.ToString());
            return _context.TourLogs.Find(id);
        }

        public List<TourLog> GetAllTourLogsByTourId(int id)
        {
            log.Info("Getting All Tour Logs By Tour Id = " + id.ToString());
            return _context.TourLogs.Where(tl => tl.Tour.Id == id).Include(tl => tl.Tour).ToList();
        }

        public void AddLog(TourLog log)
        {
            TourLogService.log.Info("Adding Tour Log");
            _context.TourLogs.Add(log);
            _context.SaveChanges();
        }

        public void UpdateLog(TourLog log)
        {
            TourLogService.log.Info("Updating Tour Log");
            _context.Entry(log).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteLog(int id)
        {
            TourLogService.log.Info("Deleting Tour Log Id = " + id.ToString());
            var log = _context.TourLogs.Find(id);
            if (log != null)
            {
                _context.TourLogs.Remove(log);
                _context.SaveChanges();
            }
        }
    }
}
