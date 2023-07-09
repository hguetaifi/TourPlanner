using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.ViewModels;

namespace TourPlanner
{
    public class ViewModelLocator
    {
        public ToursViewModel ToursVM { get; private set; }
        public TourDetailsViewModel TourDetailsVM { get; private set; }
        public TourLogsViewModel TourLogsVM { get; private set; }

        public ViewModelLocator()
        {
            ToursVM = new ToursViewModel();
            TourDetailsVM = new TourDetailsViewModel();
            TourLogsVM = new TourLogsViewModel(ToursVM);
        }
    }

}
