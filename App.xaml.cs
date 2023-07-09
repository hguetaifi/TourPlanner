using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TourPlanner.Data;
using TourPlanner.Services;
using log4net;
using log4net.Config;

namespace TourPlanner
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        private static readonly ILog log = LogManager.GetLogger(typeof(App));

        protected override void OnStartup(StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            //// Ensuring the database is deleted and created
            //using (var scope = ServiceProvider.CreateScope())
            //{
            //    var context = scope.ServiceProvider.GetRequiredService<TourPlannerDbContext>();

            //    // Delete the database, if it exists.
            //    context.Database.EnsureDeleted();

            //    // Create a new database, if it doesn't exist.
            //    context.Database.EnsureCreated();
            //}

            base.OnStartup(e);

            XmlConfigurator.Configure();

            log.Info("Application Startup");
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TourPlannerDbContext>(options =>
                options.UseNpgsql(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            services.AddScoped<ITourService, TourService>();
            services.AddScoped<ITourLogService, TourLogService>();
        }
    }
}