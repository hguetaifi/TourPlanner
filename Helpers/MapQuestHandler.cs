using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using TourPlanner.Models;
using System.IO;
using log4net;
using System.Configuration;

namespace TourPlanner.Helpers
{
    public class MapQuestHandler
    {
        private static HttpClient client = new HttpClient();

        private static string apiKey = ConfigurationManager.AppSettings["MapQuestAPIKey"];

        private static readonly ILog log = LogManager.GetLogger(typeof(App));

        public static async Task<Tour> RequestMapQuestDirectionsAPIAsync(Tour tour)
        {
            try
            {
                if (tour != null)
                {
                    string directionsUrl = $"http://www.mapquestapi.com/directions/v2/route?key={apiKey}&from={tour.From}&to={tour.To}&unit=k";
                    var response = await client.GetStringAsync(directionsUrl);
                    var data = JObject.Parse(response);

                    double distance = (double)data["route"]["distance"];
                    int time = (int)data["route"]["time"];

                    tour.Distance = distance;
                    tour.EstimatedTime = time;

                    string staticMapUrl = $"http://www.mapquestapi.com/staticmap/v5/map?key={apiKey}&start={tour.From}&end={tour.To}&size=600,400@2x";
                    var imageResponse = await client.GetByteArrayAsync(staticMapUrl);

                    var imagePath = setupImageDirectory();

                    string imageFile = Path.Combine(imagePath, $"Tour_{tour.Id}.png");

                    if (File.Exists(imageFile))
                    {
                        string existingFileName = Path.GetFileNameWithoutExtension(tour.RouteInformation);
                        string[] parts = existingFileName.Split('_');
                        int revision = 1;
                        if (parts.Length > 2 && int.TryParse(parts[2], out int existingRevision))
                        {
                            revision = existingRevision + 1;
                        }
                        imageFile = Path.Combine(imagePath, $"Tour_{tour.Id}_{revision}.png");
                        //File.Delete(imageFile);
                    }

                    tour.RouteInformation = imageFile;

                    File.WriteAllBytes(imageFile, imageResponse);

                    return tour;
                }
            }
            catch (Exception ex)
            {
                log.Error("MapQuestHandler: " + ex.Message);
            }
            
            return null;
        }

        private static string setupImageDirectory()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;

            string projectRootDirectory = Directory.GetParent(baseDir).Parent.Parent.FullName;

            string imagePath = Path.Combine(projectRootDirectory, "TourPlanner", "Images");

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }

            return imagePath;
        }
    }
}
