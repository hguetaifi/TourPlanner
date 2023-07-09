using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Helpers;
using TourPlanner.Models;
using TourPlanner.Views;

namespace TourPlanner.ViewModels
{
    public class TourLogsViewModel
    {

        private DbContextFactory _dbContextFactory;

        public DbContextFactory DbContextFactory
        {
            get { return _dbContextFactory; }
            set { _dbContextFactory = value; }
        }

        private bool _isEdit;

        public bool IsEdit
        {
            get { return _isEdit; }
            set { _isEdit = value; }
        }

        private ToursViewModel _parent;

        public ToursViewModel Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public ICommand AddTourLogCommand { get; private set; }

        public event Action RequestClose;

        public TourLogsViewModel(ToursViewModel parent)
        {
            DbContextFactory = new DbContextFactory();
            Parent = parent;

            AddTourLogCommand = new DelegateCommand(OnAddTourLog);

            //SaveTourCommand = new DelegateCommand(AddTour);
            //EditTourCommand = new DelegateCommand(EditTour);
            //DeleteTourCommand = new DelegateCommand(DeleteTour);
        }

        private void OnAddTourLog(object obj)
        {
            AddTourLogViewModel addTourlogViewModel = new AddTourLogViewModel(Parent);

            AddTourLogWindow dialog = new AddTourLogWindow(addTourlogViewModel)
            {
                DataContext = addTourlogViewModel
            };

            dialog.ShowDialog();
        }

    }
}
