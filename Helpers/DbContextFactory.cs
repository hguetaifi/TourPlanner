using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TourPlanner.Data;

namespace TourPlanner.Helpers
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly string _connectionString;

        public DbContextFactory()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString; ;
        }

        public TourPlannerDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<TourPlannerDbContext>()
                .UseNpgsql(_connectionString)
                .Options;
            return new TourPlannerDbContext(options);
        }
    }
}
