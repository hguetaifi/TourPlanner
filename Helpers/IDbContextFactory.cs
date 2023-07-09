using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Data;

namespace TourPlanner.Helpers
{
    public interface IDbContextFactory
    {
        TourPlannerDbContext CreateDbContext();
    }
}
