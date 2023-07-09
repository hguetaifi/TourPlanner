using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TourPlanner.ViewModels;

namespace TourPlanner.Views
{
    /// <summary>
    /// Interaction logic for AddTourWindow.xaml
    /// </summary>
    public partial class AddTourWindow : Window
    {
        public AddTourWindow(AddTourViewModel viewModel, bool isEdit = false)
        {
            InitializeComponent();

            viewModel.RequestClose += delegate { Close(); };

            DataContext = viewModel;

            if (isEdit)
            {
                Title = "Edit Tour";
                AddEditTourButton.Content = "Edit Tour";
            }
        }
    }
}
