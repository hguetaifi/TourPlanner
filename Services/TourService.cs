using System.Collections.Generic;
using System.Linq;
using TourPlanner.Models;
using Microsoft.EntityFrameworkCore;
using TourPlanner.Data;
using log4net;
using TourPlanner.Helpers;
using System.Threading.Tasks;

namespace TourPlanner.Services
{
    public class TourService : ITourService
    {
        private readonly TourPlannerDbContext _context;

        private static readonly ILog log = LogManager.GetLogger(typeof(App));

        public TourService(TourPlannerDbContext context)
        {
            _context = context;
        }

        public List<Tour> GetAllTours()
        {
            log.Info("Getting All Tours");
            return _context.Tours.Include(t => t.TourLogs).ToList();
        }

        public Tour GetTourById(int id)
        {
            log.Info("Getting Tour by Tour Id = " + id.ToString());
            return _context.Tours.Find(id);
        }

        public async Task AddTourAsync(Tour tour)
        {
            log.Info("Adding Tour");
            _context.Tours.Add(tour);
            _context.SaveChanges();

            tour = await MapQuestHandler.RequestMapQuestDirectionsAPIAsync(tour);

            await UpdateTourAsync(tour);
        }

        public async Task UpdateTourAsync(Tour tour, bool isFromEdit = false)
        {
            try
            {
                log.Info("Updating Tour");

                if (isFromEdit)
                    tour = await MapQuestHandler.RequestMapQuestDirectionsAPIAsync(tour);

                _context.Entry(tour).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (System.Exception ex)
            {
                log.Error("TourService: " + ex.Message);
            }
        }

        public void DeleteTour(int id)
        {
            log.Info("Deleting Tour Id = " + id.ToString());
            var tour = _context.Tours.Find(id);
            if (tour != null)
            {
                _context.Tours.Remove(tour);
                _context.SaveChanges();
            }
        }
    }
}
