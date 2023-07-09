using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

namespace TourPlanner.Services
{
    public interface ITourService
    {
        List<Tour> GetAllTours();
        Tour GetTourById(int id);
        Task AddTourAsync(Tour tour);
        Task UpdateTourAsync(Tour tour, bool isFromEdit = false);
        void DeleteTour(int id);
    }
}
