using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourPlanner.Models
{
    public class TourLog
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Comment { get; set; }
        public string Difficulty { get; set; }
        public double TotalTime { get; set; }
        public int Rating { get; set; }
        public int TourId { get; set; }  // Foreign Key for Tour
        public virtual Tour Tour { get; set; } // Tour that this log belongs to
    }

}
