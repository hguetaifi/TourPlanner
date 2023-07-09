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
    public class AddTourViewModel : BaseViewModel
    {
        private ObservableCollection<string> _transportTypes;

        public ObservableCollection<string> TransportTypes
        {
            get { return _transportTypes; }
            set { _transportTypes = value; }
        }

        private Tour _target;

        public Tour Target
        {
            get { return _target; }
            set 
            { 
                _target = value;
                OnPropertyChanged();
            }
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

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged(); // Assuming you have implemented INotifyPropertyChanged interface
            }
        }

        public ICommand SaveTourCommand { get; private set; }
        public ICommand EditTourCommand { get; set; }
        public ICommand DeleteTourCommand { get; set; }

        public event Action RequestClose;

        public AddTourViewModel(ToursViewModel parent, Tour target = null)
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
                Target = new Tour();
                IsEdit = false;
            }

            SaveTourCommand = new DelegateCommand(AddTourAsync);
            EditTourCommand = new DelegateCommand(EditTour);
            DeleteTourCommand = new DelegateCommand(DeleteTour);

            TransportTypes = new ObservableCollection<string>
            {
                "Bus",
                "Train",
                "Car"
            };
        }

        private bool validateUserInput()
        {
            if(String.IsNullOrEmpty(Target.Name) || String.IsNullOrWhiteSpace(Target.Name))
            {
                MessageBox.Show("Name cannot be empty or having only whitespaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (String.IsNullOrEmpty(Target.Description) || String.IsNullOrWhiteSpace(Target.Description))
            {
                MessageBox.Show("Description cannot be empty or having only whitespaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (String.IsNullOrEmpty(Target.From) || String.IsNullOrWhiteSpace(Target.From))
            {
                MessageBox.Show("From cannot be empty or having only whitespaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (String.IsNullOrEmpty(Target.To) || String.IsNullOrWhiteSpace(Target.To))
            {
                MessageBox.Show("To cannot be empty or having only whitespaces", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (String.IsNullOrEmpty(Target.TransportType) || String.IsNullOrWhiteSpace(Target.TransportType))
            {
                MessageBox.Show("Please choose Transport Type", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private async void AddTourAsync(object obj)
        {
            if (!validateUserInput())
                return;

            try
            {
                IsLoading = true;
                if (!IsEdit)
                {
                    using (var context = DbContextFactory.CreateDbContext())
                    {
                        var tourService = new TourService(context);
                        await tourService.AddTourAsync(Target);
                    }

                    IsLoading = false;
                    MessageBox.Show("Tour has been added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (Target != null)
                    {
                        using (var context = DbContextFactory.CreateDbContext())
                        {
                            var tourService = new TourService(context);
                            await tourService.UpdateTourAsync(Target, true);
                        }

                        IsLoading = false;
                        MessageBox.Show("Tour has been updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("An Error has occurred. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        log.Error("An Error has occurred while updating tour. Target is null");
                    }
                }

                if (!IsEdit)
                    Parent.ReadAllTours();

                if (IsEdit)
                    Parent.SelectedTour = this;

                RequestClose?.Invoke();
            }
            catch (Exception ex)
            {
                log.Error("AddTourViewModel: " + ex.Message);
            }
        }

        private void EditTour(object obj)
        {
            AddTourViewModel addTourViewModel = new AddTourViewModel(Parent, Target);

            AddTourWindow dialog = new AddTourWindow(addTourViewModel, true)
            {
                DataContext = addTourViewModel
            };

            dialog.ShowDialog();
        }

        private void DeleteTour(object obj)
        {
            if (Target != null && Target.Id > 0)
            {
                using (var context = DbContextFactory.CreateDbContext())
                {
                    var tourService = new TourService(context);
                    tourService.DeleteTour(Target.Id);
                }

                MessageBox.Show("Tour has been deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                Parent.ReadAllTours();
            }
            else
            {
                MessageBox.Show("An Error has occurred. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                log.Error("An Error has occurred while deleting tour. Target is null");
            }
        }

    }
}
