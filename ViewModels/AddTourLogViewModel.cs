using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TourPlanner.Helpers;
using TourPlanner.Models;
using TourPlanner.Services;
using TourPlanner.Views;

namespace TourPlanner.ViewModels
{
    public class AddTourLogViewModel : BaseViewModel
    {
        private TourLog _target;

        public TourLog Target
        {
            get { return _target; }
            set { _target = value; }
        }

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

        private ObservableCollection<string> _difficulties;

        public ObservableCollection<string> Difficulties
        {
            get { return _difficulties; }
            set { _difficulties = value; }
        }

        public ICommand SaveTourLogCommand { get; private set; }
        public ICommand EditTourLogCommand { get; private set; }
        public ICommand DeleteTourLogCommand { get; private set; }

        public event Action RequestClose;

        public AddTourLogViewModel(ToursViewModel parent, TourLog target = null)
        {
            DbContextFactory = new DbContextFactory();
            Parent = parent;

            if (target != null)
            {
                Target = target;
                
                IsEdit = true;
            }
            else
            {
                Target = new TourLog();
                IsEdit = false;
                Target.Date = DateTime.Now;
            }
            Target.TourId = Parent.SelectedTour.Target.Id;

            SaveTourLogCommand = new DelegateCommand(AddTourLog);
            EditTourLogCommand = new DelegateCommand(EditTourLog);
            DeleteTourLogCommand = new DelegateCommand(DeleteTourLog);

            Difficulties = new ObservableCollection<string>
            {
                "Easy",
                "Medium",
                "Hard"
            };
        }

        private bool validateUserInput()
        {
            if (String.IsNullOrEmpty(Target.Comment) || String.IsNullOrWhiteSpace(Target.Comment))
            {
                MessageBox.Show("Comment cannot be empty or having only whitespaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (String.IsNullOrEmpty(Target.Difficulty) || String.IsNullOrWhiteSpace(Target.Difficulty))
            {
                MessageBox.Show("Please choose Difficulty level", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if(Target.TotalTime <= 0)
            {
                MessageBox.Show("Please enter the total time", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (Target.Rating < 1 || Target.Rating > 5)
            {
                MessageBox.Show("Please give Rating (1-5)", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }


        private void AddTourLog(object obj)
        {
            if (!validateUserInput())
                return;

            if (!IsEdit)
            {
                using (var context = DbContextFactory.CreateDbContext())
                {
                    var tourService = new TourLogService(context);
                    tourService.AddLog(Target);
                }

                MessageBox.Show("Tour Log has been added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (Target != null)
                {
                    using (var context = DbContextFactory.CreateDbContext())
                    {
                        var tourService = new TourLogService(context);
                        tourService.UpdateLog(Target);
                    }

                    MessageBox.Show("Tour Log has been updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("An Error has occurred. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    log.Error("An Error has occurred while updating tour log. Target is null");
                }
            }

            Parent.ReadAllTours();

            RequestClose?.Invoke();
        }

        private void EditTourLog(object obj)
        {
            AddTourLogViewModel addTourLogViewModel = new AddTourLogViewModel(Parent, Target);

            AddTourLogWindow dialog = new AddTourLogWindow(addTourLogViewModel, true)
            {
                DataContext = addTourLogViewModel
            };

            dialog.ShowDialog();
        }

        private void DeleteTourLog(object obj)
        {
            if (Target != null && Target.Id > 0)
            {
                using (var context = DbContextFactory.CreateDbContext())
                {
                    var tourLogService = new TourLogService(context);
                    tourLogService.DeleteLog(Target.Id);
                }

                MessageBox.Show("Tour Log has been deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                Parent.ReadAllTours();
            }
            else
            {
                MessageBox.Show("An Error has occurred. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                log.Error("An Error has occurred while deleting tour log. Target is null");
            }
        }


    }
}
