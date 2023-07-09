using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

namespace TourPlanner.Services
{
    public interface ITourLogService
    {
        List<TourLog> GetAllLogs();
        TourLog GetLogById(int id);
        void AddLog(TourLog log);
        void UpdateLog(TourLog log);
        void DeleteLog(int id);
        List<TourLog> GetAllTourLogsByTourId(int id);
    }
}
