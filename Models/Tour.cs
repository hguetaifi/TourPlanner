using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Helpers;
using TourPlanner.ViewModels;
using TourPlanner.Views;

namespace TourPlanner.Models
{
    public class Tour : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string TransportType { get; set; }

        private double _distance;
        public double Distance
        {
            get { return _distance; }
            set
            {
                _distance = value;
                OnPropertyChanged();
            }
        }

        private double _estimatedTime;
        public double EstimatedTime
        {
            get { return _estimatedTime; }
            set
            {
                _estimatedTime = value;
                OnPropertyChanged();
            }
        }

        private string _routeInformation;
        public string RouteInformation
        {
            get { return _routeInformation; }
            set
            {
                _routeInformation = value;
                OnPropertyChanged();
            }
        }
        public virtual ICollection<TourLog> TourLogs { get; set; } = new HashSet<TourLog>();

        [NotMapped]
        public int Popularity
        {
            get { return TourLogs?.Count ?? 0; }
        }

        [NotMapped]
        public double ChildFriendliness
        {
            get
            {
                if (TourLogs == null || !TourLogs.Any()) return 0;

                double avgDifficulty = TourLogs.Average(log => DifficultyToNumeric(log.Difficulty));
                double avgTime = TourLogs.Average(log => log.TotalTime);
                double avgDistance = Distance;

                if (avgDifficulty == 0)
                    avgDifficulty = 1;

                if (avgTime == 0)
                    avgTime = 1;

                if (avgDistance == 0)
                    avgDistance = 1;

                return 1 / (avgDifficulty * avgTime * avgDistance);
            }
        }

        private double DifficultyToNumeric(string difficulty)
        {
            switch (difficulty.ToLower())
            {
                case "easy": return 1;
                case "medium": return 2;
                case "hard": return 3;
                default: return 1;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
