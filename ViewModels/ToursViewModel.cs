using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using Microsoft.Win32;
using TourPlanner.Helpers;
using TourPlanner.Models;
using TourPlanner.Services;
using TourPlanner.Views;

namespace TourPlanner.ViewModels
{

    public class ToursViewModel : BaseViewModel
    {

        private ObservableCollection<AddTourViewModel> _tours;

        public ObservableCollection<AddTourViewModel> Tours
        {
            get { return _tours; }
            set { _tours = value; }
        }

        private ObservableCollection<AddTourLogViewModel> _toursLogs;

        public ObservableCollection<AddTourLogViewModel> ToursLogs
        {
            get { return _toursLogs; }
            set { _toursLogs = value; }
        }

        private AddTourViewModel _selectedTour;

        public AddTourViewModel SelectedTour
        {
            get { return _selectedTour; }
            set 
            { 
                _selectedTour = value;
                AddTourLogsToVm();
                OnPropertyChanged(); 
            }
        }

        private DbContextFactory _dbContextFactory;

        public DbContextFactory DbContextFactory
        {
            get { return _dbContextFactory; }
            set { _dbContextFactory = value; }
        }

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();

                UpdateFilteredToursList();
            }
        }

        private ObservableCollection<AddTourViewModel> _filteredToursList;
        public ObservableCollection<AddTourViewModel> FilteredToursList
        {
            get { return _filteredToursList; }
            set
            {
                _filteredToursList = value;
                OnPropertyChanged();
            }
        }

        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                OnPropertyChanged();
            }
        }


        public ICommand AddTourCommand { get; private set; }
        public ICommand ImportCommand { get; private set; }
        public ICommand ExportCommand { get; private set; }
        public ICommand GenerateReportCommand { get; private set; }
        public ICommand GenerateSummarizeReportCommand { get; private set; }

        public ToursViewModel()
        {
            DbContextFactory = new DbContextFactory();

            AddTourCommand = new DelegateCommand(OnAddTour);
            ImportCommand = new DelegateCommand(OnImportToursAsync);
            ExportCommand = new DelegateCommand(OnExportTours);
            GenerateReportCommand = new DelegateCommand(OnGenerateReport);
            GenerateSummarizeReportCommand = new DelegateCommand(OnGenerateSummarizeReport);

            if (Tours == null)
                Tours = new ObservableCollection<AddTourViewModel>();

            if (FilteredToursList == null)
                FilteredToursList = new ObservableCollection<AddTourViewModel>();

            FilteredToursList = new ObservableCollection<AddTourViewModel>(Tours);

            ReadAllTours();
        }

        public void ReadAllTours()
        {
            Tours.Clear();
            FilteredToursList.Clear();

            using (var context = DbContextFactory.CreateDbContext())
            {
                var tourService = new TourService(context);
                var tourList = tourService.GetAllTours();

                foreach (var item in tourList)
                {
                    var temp = new AddTourViewModel(this, item);
                    Tours.Add(temp);
                    FilteredToursList.Add(temp);
                }
            }

            if (FilteredToursList != null && FilteredToursList.Count > 0)
            {
                SelectedTour = FilteredToursList.FirstOrDefault();
            }
        }

        private void UpdateFilteredToursList()
        {
            if (FilteredToursList == null)
                FilteredToursList = new ObservableCollection<AddTourViewModel>();
            FilteredToursList.Clear();
            foreach (var item in Tours)
            {
                if (FilterTour(item))
                {
                    FilteredToursList.Add(item);
                }
            }

            if (FilteredToursList != null && FilteredToursList.Count > 0)
            {
                SelectedTour = FilteredToursList.FirstOrDefault();
            }
        }

        private bool FilterTour(object obj)
        {
            if (string.IsNullOrEmpty(SearchText))
                return true;

            var tour = obj as AddTourViewModel;
            return tour.Target.Name.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void OnAddTour(object obj)
        {
            AddTourViewModel addTourViewModel = new AddTourViewModel(this);

            AddTourWindow dialog = new AddTourWindow(addTourViewModel)
            {
                DataContext = addTourViewModel
            };

            dialog.ShowDialog();
        }

        private void OnGenerateReport(object obj)
        {
            GenerateTourReport(SelectedTour);
        }

        private void OnGenerateSummarizeReport(object obj)
        {
            GenerateSummaryReport();
        }

        private void AddTourLogsToVm()
        {
            if (ToursLogs == null)
                ToursLogs = new ObservableCollection<AddTourLogViewModel>();

            if (SelectedTour == null || SelectedTour.Target == null)
                return;

            ToursLogs.Clear();

            foreach (var item in SelectedTour.Target.TourLogs)
            {
                ToursLogs.Add(new AddTourLogViewModel(this, item));
            }
        }

        private string GetFileForImport()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                return filePath;
            }
            return null;
        }

        public async void OnImportToursAsync(object obj)
        {
            string filePath = GetFileForImport();
            if(filePath == null)
            {
                log.Error("Couldn't Get File from File Dialogue");
                return;
            }

            IsLoading = true;
            try
            {
                if (File.Exists(filePath))
                {
                    var lines = File.ReadLines(filePath);
                    foreach (var line in lines)
                    {
                        var values = line.Split(';');
                        if (values.Length >= 5)
                        {
                            var tour = new Tour()
                            {
                                Name = values[0].Trim(),
                                Description = values[1].Trim(),
                                From = values[2].Trim(),
                                To = values[3].Trim(),
                                TransportType = values[4].Trim()
                            };

                            using (var context = DbContextFactory.CreateDbContext())
                            {
                                var tourService = new TourService(context);
                                await tourService.AddTourAsync(tour);
                            }
                        }
                    }
                    MessageBox.Show("Tours has been imported successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    ReadAllTours();
                }
                else
                {
                    MessageBox.Show("File " + filePath + " doesn't exist", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    log.Error("File " + filePath + " doesn't exist");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error reading file: {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                log.Error($"Error reading file: {e.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public void OnExportTours(object obj)
        {
            string filePath = FileDialogueHandler.GetFilePathForExport();
            if (filePath == null)
            {
                log.Error("Couldn't Get Folder Path from Folder Dialogue");
                return;
            }
            IsLoading = true;
            try
            {
                var lines = new List<string>();
                foreach (var tour in Tours)
                {
                    lines.Add($"{tour.Target.Name}; {tour.Target.Description}; {tour.Target.From}; {tour.Target.To}; {tour.Target.TransportType}");
                }
                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Tours has been exported successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error writing file: {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                log.Error($"Error writing file: {e.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        public void GenerateTourReport(AddTourViewModel tour)
        {
            IsLoading = true;
            using (var stream = new FileStream("TourReport_" + tour.Target.Id.ToString() + ".pdf", FileMode.Create))
            {
                var pdfDoc = new iTextSharp.text.Document();
                var pdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);

                pdfDoc.SetMargins(36, 36, 36, 36);

                pdfDoc.Open();

                var boldFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
                var normalFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL);

                pdfDoc.Add(CreateParagraph("Name: ", tour.Target.Name, boldFont, normalFont));
                pdfDoc.Add(CreateParagraph("Description: ", tour.Target.Description, boldFont, normalFont));
                pdfDoc.Add(CreateParagraph("From: ", tour.Target.From, boldFont, normalFont));
                pdfDoc.Add(CreateParagraph("To: ", tour.Target.To, boldFont, normalFont));
                pdfDoc.Add(CreateParagraph("TransportType: ", tour.Target.TransportType, boldFont, normalFont));
                pdfDoc.Add(CreateParagraph("Distance: ", tour.Target.Distance.ToString(), boldFont, normalFont));
                pdfDoc.Add(CreateParagraph("EstimatedTime: ", tour.Target.EstimatedTime.ToString(), boldFont, normalFont));

                pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                pdfDoc.Add(new iTextSharp.text.Paragraph(new iTextSharp.text.Chunk("Map:", boldFont)));

                var imgPath = tour.Target.RouteInformation;
                if (File.Exists(imgPath))
                {
                    var image = iTextSharp.text.Image.GetInstance(imgPath);
                    image.ScaleToFit(400f, 600f);
                    pdfDoc.Add(image);
                }

                pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                pdfDoc.Add(new iTextSharp.text.Paragraph(new iTextSharp.text.Chunk("Tour Logs:", boldFont)));
                pdfDoc.Add(new iTextSharp.text.Paragraph("\n"));

                var table = new iTextSharp.text.pdf.PdfPTable(5);

                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Date", boldFont)));
                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Comment", boldFont)));
                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Difficulty", boldFont)));
                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("TotalTime", boldFont)));
                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Rating", boldFont)));

                foreach (var tlog in tour.Target.TourLogs)
                {
                    table.AddCell(tlog.Date.ToString());
                    table.AddCell(tlog.Comment);
                    table.AddCell(tlog.Difficulty.ToString());
                    table.AddCell(tlog.TotalTime.ToString());
                    table.AddCell(tlog.Rating.ToString());
                }
                pdfDoc.Add(table);

                pdfDoc.Close();
                pdfWriter.Close();
            }
            IsLoading = false;

            MessageBox.Show("Tour Report has been generated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private static iTextSharp.text.Paragraph CreateParagraph(string boldText, string normalText, iTextSharp.text.Font boldFont, iTextSharp.text.Font normalFont)
        {
            var paragraph = new iTextSharp.text.Paragraph();
            paragraph.Add(new iTextSharp.text.Chunk(boldText, boldFont));
            paragraph.Add(new iTextSharp.text.Chunk(normalText, normalFont));
            return paragraph;
        }

        public void GenerateSummaryReport()
        {
            IsLoading = true;
            using (var stream = new FileStream("SummaryReport.pdf", FileMode.Create))
            {
                var pdfDoc = new iTextSharp.text.Document();
                var pdfWriter = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();

                var boldFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);

                var table = new iTextSharp.text.pdf.PdfPTable(6);

                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Tour Id", boldFont)));
                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Tour Name", boldFont)));
                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Distance", boldFont)));
                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Estimated Time", boldFont)));
                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Average Time", boldFont)));
                table.AddCell(new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase("Average Rating", boldFont)));

                foreach (var tour in Tours)
                {
                    table.AddCell(tour.Target.Id.ToString());
                    table.AddCell(tour.Target.Name);
                    table.AddCell(tour.Target.Distance.ToString());
                    table.AddCell(tour.Target.EstimatedTime.ToString());

                    if (tour.Target.TourLogs.Any())
                    {
                        table.AddCell(tour.Target.TourLogs.Average(log => log.TotalTime).ToString());
                        table.AddCell(tour.Target.TourLogs.Average(log => log.Rating).ToString());
                    }
                    else
                    {
                        table.AddCell("N/A");
                        table.AddCell("N/A");
                    }
                }

                pdfDoc.Add(table);

                pdfDoc.Close();
                pdfWriter.Close();
            }
            IsLoading = false;
            MessageBox.Show("Summarized Report has been generated successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}
