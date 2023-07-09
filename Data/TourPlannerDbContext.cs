using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourPlanner.Models;

namespace TourPlanner.Data
{
    public class TourPlannerDbContext : DbContext
    {
        public TourPlannerDbContext(DbContextOptions<TourPlannerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
        public DbSet<TourLog> TourLogs { get; set; }
    }

}
